using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using PostOffice.API.DTOs.User;
using PostOffice.API.Repositorities.User;

namespace PostOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDTO userLoginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _userRepository.Authenticate(userLoginDTO);

            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("email or password is incorrect.");
            }
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userRepository.Register(userRegisterDTO);
            if (!result)
            {
                return BadRequest("Register is unsucessfull.");
            }
            return Ok();
        }
    }
}
