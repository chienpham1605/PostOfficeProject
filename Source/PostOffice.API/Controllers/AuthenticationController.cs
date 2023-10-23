using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.User;
using PostOffice.API.Utilities;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PostOffice.API.Controllers
{
   /* [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IEmailSender emailSender, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            //check User exist
            var userExist = await _userManager.FindByEmailAsync(userRegisterDTO.Email);
            if (userExist != null)
            {
                return StatusCode(403, new Response { Status = "Error", Message = "User aldready exists." });
            }
            //add new user to db
            AppUser user = new AppUser()
            {
                Email = userRegisterDTO.Email,
                FirstName = userRegisterDTO.FirstName, 
                LastName = userRegisterDTO.LastName ,
                UserName = userRegisterDTO.Username,
                Create_date = userRegisterDTO.Create_date
            };
            if (await _roleManager.RoleExistsAsync(userRegisterDTO.Roles))
            {
                var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);

                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Failed to create." });
                }
                //add role to user
                await _userManager.AddToRoleAsync(user, userRegisterDTO.Roles);

                //Add token to verify emmail
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email }, "Confirm email link", confirmationLink);
                _emailSender.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = $"User is created & Email is sent to {user.Email}" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This role is not exist." });
            }
        }


        [HttpGet]
        [Route("send-mail")]
        public async Task<IActionResult> TestEmail()
        {
            var message = new Message(
               new string[] { "nguyenphuonghoa0709@gmail.com" },
               "Test",
               "this is for test purpose"
            );

            _emailSender.SendEmail(message);

            return StatusCode(200, new Response
            {
                Status = "success",
                Message = "Email sent successfully",
            });
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = "Email is verified successfully." }
                        );
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error", Message = "This user is not exist." }
                );
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginModel)
        {
            //check user
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {

                //create claim list
                var authClaims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, user.UserName)   ,
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var userRoles = await _userManager.GetRolesAsync(user);

                //add role to the claim
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                //generate the token with claim
                var jwtToken = GetToken(authClaims);

                //return the token
                return Ok(new UserBaseDTO
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    TokenExpire = jwtToken.ValidTo,
                    Id = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    Create_date = user.Create_date
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email }, "Confirm email link", forgotPasswordLink);
                _emailSender.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Status = "Success",
                    Message = $"Password changed request is sent on Email {user.Email}. Please verify your email"
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new Response
            {
                Status = "Error",
                Message = "Could not send link to email, please try again."
            });

        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new UserResetPasswordDTO { Token = token, Email = email };

            return Ok(new
            {
                model
            });
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDTO resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user != null)
            {
                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                if (!resetPasswordResult.Succeeded)
                {
                    foreach (var error in resetPasswordResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);

                    }
                    return Ok(ModelState);
                }

                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Status = "Success",
                    Message = "Password has been changed."
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new Response
            {
                Status = "Error",
                Message = "Could not send link to email, please try again."
            });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                 issuer: _configuration["JWT:ValidAudience"],
                 audience: _configuration["JWT:ValidIssuer"],
                 expires: DateTime.UtcNow.AddHours(10),
                 claims: authClaims,
                 signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }*/
}
