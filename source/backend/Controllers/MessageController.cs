using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using O9d.AspNet.FluentValidation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Route("api/channels/{channelId}/conversations/{conversationId}/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private User user = new User
        {
            Id = 1,
            Username = "system",
            Password = "password",
            Email = "system@forum.com",
            Avatar = "image.url"
        };
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/<MessageController>
        [HttpGet]
        public async Task<IActionResult> Get(int channelId, int conversationId)
        {
            var messages = await _messageService.GetAll();
            if (messages != null && messages.Count > 0)
            {
                return Ok(messages);
            }
            return NoContent();
        }

        // GET api/<MessageController>/5
        [HttpGet("{messageId}")]
        public async Task<IActionResult> Get(int channelId, int conversationId, int messageId)
        {
            var message = await _messageService.Get(messageId);
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
            var result = await _messageService.Add(createMessageDTO, user);
            if (result > 0)
            {
                return Ok(new
                {
                    id = result
                });
            }
            return BadRequest("Wrong provided data");
        }

        // PUT api/<MessageController>/5
        [HttpPut("{messageId}")]
        public async Task<IActionResult> Put(int channelId, int conversationId, int messageId, [Validate] UpdateMessageDTO updateMessageDTO)
        {
            var result = await _messageService.Update(updateMessageDTO, messageId, user);
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
            var result = await _messageService.Delete(messageId);
            if(result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided id");
        }
    }
}
