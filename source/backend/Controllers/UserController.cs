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
        
    }
}
