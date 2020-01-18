using GameLibrary.Domain.Entities.Token;
using GameLibrary.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace GameLibrary.Domain.Services
{
    public class TokenService : ITokenService
    {
        public async Task<bool> ValidateCredentials(AccessTokenCredentials credenciais)
        {
            bool credenciaisValidas = false;
            //if (credenciais != null && !String.IsNullOrWhiteSpace(credenciais.UserID))
            //{
            //    if (credenciais.GrantType == "password")
            //    {
            //        // Verifica a existência do usuário nas tabelas do
            //        // ASP.NET Core Identity
            //        var userIdentity = _userManager
            //            .FindByNameAsync(credenciais.UserID).Result;
            //        if (userIdentity != null)
            //        {
            //            // Efetua o login com base no Id do usuário e sua senha
            //            var resultadoLogin = _signInManager
            //                .CheckPasswordSignInAsync(userIdentity, credenciais.Password, false)
            //                .Result;
            //            if (resultadoLogin.Succeeded)
            //            {
            //                // Verifica se o usuário em questão possui
            //                // a role Acesso-APIProdutos
            //                credenciaisValidas = _userManager.IsInRoleAsync(
            //                    userIdentity, Roles.ROLE_API_PRODUTOS).Result;
            //            }
            //        }
            //    }
            //    else if (credenciais.GrantType == "refresh_token")
            //    {
            //        if (!String.IsNullOrWhiteSpace(credenciais.RefreshToken))
            //        {
            //            RefreshTokenData refreshTokenBase = null;

            //            string strTokenArmazenado =
            //                _cache.GetString(credenciais.RefreshToken);
            //            if (!String.IsNullOrWhiteSpace(strTokenArmazenado))
            //            {
            //                refreshTokenBase = JsonConvert
            //                    .DeserializeObject<RefreshTokenData>(strTokenArmazenado);
            //            }

            //            credenciaisValidas = (refreshTokenBase != null &&
            //                credenciais.UserID == refreshTokenBase.UserID &&
            //                credenciais.RefreshToken == refreshTokenBase.RefreshToken);

            //            // Elimina o token de refresh já que um novo será gerado
            //            if (credenciaisValidas)
            //                _cache.Remove(credenciais.RefreshToken);
            //        }
            //    }
            //}

            return credenciaisValidas;
        }
    }
}
