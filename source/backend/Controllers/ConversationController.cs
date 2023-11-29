using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O9d.AspNet.FluentValidation;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Authorize]
    [Route("api/channels/{channelId}/conversations")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;
        private readonly IUserService _userService;
        public ConversationController(IConversationService conversationService, IUserService userService)
        {
            _conversationService = conversationService;
            _userService = userService;
        }
        // GET: api/<ConversationController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(int channelId)
        {
            var result = await _conversationService.Get(channelId);
            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }
            return NoContent();
        }

        // GET api/<ConversationController>/5
        [AllowAnonymous]
        [HttpGet("{conversationId}")]
        public async Task<IActionResult> Get(int channelId, int conversationId)
        {
            var result = await _conversationService.Get(channelId, conversationId);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        // POST api/<ConversationController>
        [HttpPost]
        public async Task<IActionResult> Post(int channelId, [Validate]CreateConversationDTO createConversationDTO)
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userService.GetAsync(username);
            var result = await _conversationService.Add(createConversationDTO, channelId, (int)user.Id);
            if (result > 0)
            {
                return Created("", result);
            }
            return BadRequest("Wrong provided data");
        }

        // PUT api/<ConversationController>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{conversationId}")]
        public async Task<IActionResult> Put(int channelId, int conversationId, [Validate]UpdateConversationDTO updateConversationDTO)
        {
            var result = await _conversationService.Update(updateConversationDTO, channelId, conversationId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided data");
        }

        // DELETE api/<ConversationController>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{conversationId}")]
        public async Task<IActionResult> Delete(int channelId, int conversationId)
        {
            var result = await _conversationService.Delete(channelId, conversationId);
            if (result)
            {
                return NoContent();
            }
            return BadRequest("Wrong data id");
        }
    }
}
