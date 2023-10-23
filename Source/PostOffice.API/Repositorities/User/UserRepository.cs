using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PostOffice.API.Repositorities.User
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserRepository(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            RoleManager<AppRole> roleManager, 
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;

        }

        public async Task<string> Authenticate(UserLoginDTO userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);
            if (user == null)  return null;

            var result = await _signInManager.PasswordSignInAsync(user, userLogin.Password, userLogin.RememberMe, true);

            if(!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";", roles)),
                new Claim(ClaimTypes.Name, user.LastName),                
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.PostalCode, user.PincodeId),
                new Claim(ClaimTypes.StreetAddress, user.Address),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JWT:ValidIssuer"],
               _config["JWT:ValidAudience"],
               claims,
               expires: DateTime.Now.AddHours(3),
               signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        public async Task<bool> Register(UserRegisterDTO userRegister)
        {
           var user = new AppUser()
            {
                Email = userRegister.Email,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                UserName = userRegister.Username,
                PhoneNumber = userRegister.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, userRegister.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
