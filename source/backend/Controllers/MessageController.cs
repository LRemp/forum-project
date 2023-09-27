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
            return Ok(messages);
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var message = await _messageService.Get(id);
            return Ok(message);
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMessageDTO createMessageDTO)
        {
            await _messageService.Add(createMessageDTO, user);
            return NoContent();
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreateMessageDTO createMessageDTO, int id)
        {
            await _messageService.Update(createMessageDTO, id, user);
            return NoContent();
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _messageService.Delete(id);
        }
    }
}
