using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController() 
        {

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {

        }
    }
}
