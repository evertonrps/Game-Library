using GameLibrary.Domain.Core;
using GameLibrary.Domain.Entities.Token;
using GameLibrary.Domain.Interfaces.Repositories;
using GameLibrary.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly IOptions<AppSettings> _configuration;

        public TokenService(IUsuarioRepository usuarioRepository, IOptions<AppSettings> configuration)
        {
            _usuarioRepository = usuarioRepository;
            _tokenConfigurations = new TokenConfigurations();
            _signingConfigurations = new SigningConfigurations();
            _configuration = configuration;
        }

        public async Task<bool> ValidateCredentials(AccessTokenCredentials credenciais)
        {
            bool credenciaisValidas = false;
            if (credenciais != null && !String.IsNullOrWhiteSpace(credenciais.CPF))
            {
                if (credenciais.GrantType == "password")
                {
                    var usuario = await _usuarioRepository.FindAsync(x => x.CPF == credenciais.CPF);

                    if (usuario != null)
                    {
                        // Validar senha
                        ///TODO implementar hash de validação
                        var resultadoLogin = usuario.SenhaHash == credenciais.Password;
                        if (resultadoLogin)
                        {
                            credenciaisValidas = true;
                            // Verifica se o usuário em questão possui
                            // a role Acesso-APIProdutos
                            //credenciaisValidas = _userManager.IsInRoleAsync(
                            //    userIdentity, Roles.ROLE_API_PRODUTOS).Result;
                        }
                    }
                }
                else if (credenciais.GrantType == "refresh_token")
                {
                    //if (!String.IsNullOrWhiteSpace(credenciais.RefreshToken))
                    //{
                    //    RefreshTokenData refreshTokenBase = null;

                    //    string strTokenArmazenado = _cache.GetString(credenciais.RefreshToken);

                    //    if (!String.IsNullOrWhiteSpace(strTokenArmazenado))
                    //    {
                    //        refreshTokenBase = JsonConvert
                    //            .DeserializeObject<RefreshTokenData>(strTokenArmazenado);
                    //    }

                    //    credenciaisValidas = (refreshTokenBase != null &&
                    //        credenciais.CPF == refreshTokenBase.CPF &&
                    //        credenciais.RefreshToken == refreshTokenBase.RefreshToken);

                    //    // Elimina o token de refresh já que um novo será gerado
                    //    if (credenciaisValidas)
                    //        _cache.Remove(credenciais.RefreshToken);
                    //}
                }
            }

            return credenciaisValidas;
        }

        public Token GenerateToken(AccessTokenCredentials credenciais)
        {
            try
            {

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromMinutes(_configuration.Value.SecurityTokenExpirationMinutesParameter);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.Value.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                          //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                          //new Claim(JwtRegisteredClaimNames.UniqueName, credenciais.UserID),
                          new Claim(ClaimTypes.Name, credenciais.CPF.ToString())
                    }),
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
               
                var token = tokenHandler.WriteToken(securityToken);

                var resultado = new Token()
                {
                    Authenticated = true,
                    Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    AccessToken = token,
                    RefreshToken = Guid.NewGuid().ToString().Replace("-", String.Empty),
                    Message = "OK"
                };


                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
