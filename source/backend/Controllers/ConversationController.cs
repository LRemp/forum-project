using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;
        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }
        // GET: api/<ConversationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _conversationService.Get();
            return Ok(result);
        }

        // GET api/<ConversationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _conversationService.Get(id);
            return Ok(result);
        }

        // POST api/<ConversationController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateConversationDTO createConversationDTO, int id)
        {
            await _conversationService.Add(createConversationDTO, id);
            return NoContent();
        }

        // PUT api/<ConversationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreateConversationDTO createConversationDTO, int id)
        {
            await _conversationService.Update(createConversationDTO, id);
            return NoContent();
        }

        // DELETE api/<ConversationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _conversationService.Delete(id);
            return NoContent();
        }
    }
}
