using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PostOffice.API.DTOs.User;
using PostOffice.Client.Services;
using PostOffice_Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PostOffice.Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAPIClient _userAPIClient;
        private readonly IConfiguration _configuration;

        public AccountController(IUserAPIClient userAPIClient, 
            IConfiguration configuration)
        {
            _userAPIClient = userAPIClient;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var token = await _userAPIClient.Authenticate(user);
            var userPrincipal = this.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true
            };
            await HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      userPrincipal,
                      authProperties);

            return RedirectToAction("Index", "Home", new {area = "Client"});
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private ClaimsPrincipal ValidateToken (string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();


            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _configuration["JWT:ValidAudience"];
            validationParameters.ValidIssuer = _configuration["JWT:ValidIssuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
            return principal;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = User.Identity.Name;
            return View();
        }


    }
}
