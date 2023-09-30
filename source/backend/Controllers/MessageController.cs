using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get()
        {
            var messages = await _messageService.GetAll();
            if(messages != null && messages.Count > 0)
            {
                return Ok(messages);
            }
            return NoContent();
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var message = await _messageService.Get(id);
            if(message != null)
            {
                return Ok(message);
            }
            return NoContent();
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMessageDTO createMessageDTO)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreateMessageDTO createMessageDTO, int id)
        {
            var result = await _messageService.Update(createMessageDTO, id, user);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided data");
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _messageService.Delete(id);
            if(result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided id");
        }
    }
}
