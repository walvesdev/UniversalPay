using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Api.Auth
{
    public class LoginServiceApi
    {
        public SigningConfigurations SigningConfigurations { get; set; }
        public TokenConfigurations TokenConfigurations { get; set; }

        public LoginServiceApi(
              SigningConfigurations signingConfigurations
            , TokenConfigurations tokenConfigurations)
        {
            SigningConfigurations = signingConfigurations;
            TokenConfigurations = tokenConfigurations;
        }
        

        public AccessToken LoginJwt(User User)
        {

            bool credenciaisValidas = false;

            User UserBase = null;

            if (User != null && !String.IsNullOrWhiteSpace(User.Email))
            {
                UserBase = new User
                {
                    Email = "email@email.com",
                    Password = "123",
                    Role = User.Role                    
                };

                credenciaisValidas = (UserBase != null &&
                     User.Email == UserBase.Email &&
                     User.Password == UserBase.Password);
            }


            if (credenciaisValidas)
            {

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromMinutes(TokenConfigurations.Minutes);

                ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(UserBase.Email, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, UserBase.Email),
                        new Claim(ClaimTypes.Role, UserBase.Role.Name),
                        new Claim(ClaimTypes.Name, UserBase.Email),
                        new Claim("UserId", UserBase.Id.ToString()),
                }
            );             

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = TokenConfigurations.Issuer,
                    Audience = TokenConfigurations.Audience,
                    SigningCredentials = SigningConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new AccessToken()
                {
                    Authenticated = true,
                    Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    Message = "OK",
                    Token = token,
                    UserId = UserBase.Id
                };
            }
            else
            {
                return new AccessToken()
                {
                    Authenticated = false,
                    Message = "Falha ao autenticar"
                };
            }
        }
    }
}


