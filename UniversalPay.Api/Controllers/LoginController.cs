using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversalPay.Api.Auth;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginServiceApi loginServices;

        public LoginController(LoginServiceApi loginServices)
        {
            this.loginServices = loginServices;
        }

        [AllowAnonymous]
        [HttpPost]
        public AccessToken Post([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return new AccessToken
                {
                    Message = "Usuario e senha precisam ser preenchidos corretamente."
                };
            }
            return loginServices.LoginJwt(user);
        }
    }
}