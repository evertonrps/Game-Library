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
        private readonly IOptions<AppSettings> _configuration;
        private readonly IDistributedCache _cache;

        public TokenService(IUsuarioRepository usuarioRepository, IOptions<AppSettings> configuration, IDistributedCache cache)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _cache = cache;
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
                        return usuario.SenhaHash == credenciais.Password;

                    }
                }
                else if (credenciais.GrantType == "refresh_token")
                {
                    if (!string.IsNullOrWhiteSpace(credenciais.RefreshToken))
                    {
                        RefreshTokenData refreshTokenBase = null;

                        string strTokenArmazenado = _cache.GetString(credenciais.RefreshToken);

                        if (!string.IsNullOrWhiteSpace(strTokenArmazenado))
                        {
                            refreshTokenBase = JsonConvert
                                .DeserializeObject<RefreshTokenData>(strTokenArmazenado);
                        }

                        credenciaisValidas = (refreshTokenBase != null &&
                            credenciais.UserID == refreshTokenBase.UserID &&
                            credenciais.RefreshToken == refreshTokenBase.RefreshToken);

                        // Elimina o token de refresh já que um novo será gerado
                        if (credenciaisValidas)
                            _cache.Remove(credenciais.RefreshToken);
                    }
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
                          new Claim("CPF", credenciais.CPF.ToString())
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

                // Armazena o refresh token em cache através do Redis 
                var refreshTokenData = new RefreshTokenData();
                refreshTokenData.RefreshToken = resultado.RefreshToken;
                refreshTokenData.UserID = credenciais.UserID;


                // Calcula o tempo máximo de validade do refresh token
                // (o mesmo será invalidado automaticamente pelo Redis)
                TimeSpan finalExpiration =
                    TimeSpan.FromMinutes(_configuration.Value.FinalExpiration);

                DistributedCacheEntryOptions opcoesCache =
                    new DistributedCacheEntryOptions();
                opcoesCache.SetAbsoluteExpiration(finalExpiration);
                _cache.SetString(resultado.RefreshToken,
                    JsonConvert.SerializeObject(refreshTokenData),
                    opcoesCache);


                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
