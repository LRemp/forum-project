using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O9d.AspNet.FluentValidation;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Authorize]
    [Route("api/channels/{channelId}/conversations/{conversationId}/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        // GET: api/<MessageController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(int conversationId)
        {
            var messages = await _messageService.Get(conversationId);
            if (messages != null && messages.Count > 0)
            {
                return Ok(messages);
            }
            return NoContent();
        }

        // GET api/<MessageController>/5
        [AllowAnonymous]
        [HttpGet("{messageId}")]
        public async Task<IActionResult> Get(int channelId, int conversationId, int messageId)
        {
            var message = await _messageService.Get(conversationId, messageId);
            if (message != null)
            {
                return Ok(message);
            }
            return NoContent();
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<IActionResult> Post(int channelId, int conversationId, [Validate] CreateMessageDTO createMessageDTO)
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userService.GetAsync(username);
            var result = await _messageService.Add(createMessageDTO, (int)user.Id, conversationId);
            if (result > 0)
            {
                return Created("", result);
            }
            return BadRequest("Wrong provided data");
        }

        // PUT api/<MessageController>/5
        [HttpPut("{messageId}")]
        public async Task<IActionResult> Put(int channelId, int conversationId, int messageId, [Validate] UpdateMessageDTO updateMessageDTO)
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var roles = HttpContext.User.FindAll(ClaimTypes.Role);
            var user = await _userService.GetAsync(username);
            var messageAuthor = await _messageService.GetAuthor(messageId);

            if (user.Id != messageAuthor)
            {
                return BadRequest("Not an author of the resource");
            }

            var result = await _messageService.Update(updateMessageDTO, (int)user.Id, conversationId, messageId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided data");
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{messageId}")]
        public async Task<IActionResult> Delete(int channelId, int conversationId, int messageId)
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var roles = HttpContext.User.FindAll(ClaimTypes.Role);
            var user = await _userService.GetAsync(username);
            var messageAuthor = await _messageService.GetAuthor(messageId);
            //var isAdmin = roles.Select(role => role.Value == "Administrator");

            if (user.Id != messageAuthor)
            {
                return BadRequest("Not an author of the resource");
            }

            var result = await _messageService.Delete((int)user.Id, conversationId, messageId);
            if(result)
            {
                return NoContent();
            }
            return BadRequest("Wrong provided id");
        }
    }
}
