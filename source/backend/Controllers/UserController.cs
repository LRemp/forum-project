using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Services.Services;
using Microsoft.AspNetCore.Mvc;
using O9d.AspNet.FluentValidation;

namespace Backend.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenService;
        public UserController(IUserService userService, IJwtTokenService jwtTokenService) 
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([Validate]RegisterDTO registerDTO)
        {
            var user = await _userService.GetAsync(registerDTO.Username);
            if (user != null)
            {
                return BadRequest("User already exists");
            }
            await _userService.AddAsync(registerDTO);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([Validate]LoginDTO loginDTO)
        {
            var user = await _userService.GetAsync(loginDTO.Username);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            bool isPasswordValid = await _userService.CheckPasswordAsync(loginDTO);
            if(!isPasswordValid)
            {
                return BadRequest("Wrong password");
            }

            var userRoles = await _userService.GetUserRoles((int)user.UserId);
            var token = _jwtTokenService.CreateAccessToken(user.Username, (int)user.UserId, userRoles);
            var refreshToken = _jwtTokenService.CreateRefreshToken((int)user.UserId);

            var successfulLoginDto = new SuccessfulLoginDTO
            {
                Token = token,
                RefreshToken = refreshToken,
                Username = user.Username,
            };
            return Ok(successfulLoginDto);
        }
    }
}
