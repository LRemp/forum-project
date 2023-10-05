using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using O9d.AspNet.FluentValidation;
using System.ComponentModel.DataAnnotations;

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
            if(result != null && result.Count > 0)
            {
                return Ok(result);
            }
            return NoContent();
        }

        // GET api/<ConversationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _conversationService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        // POST api/<ConversationController>
        [HttpPost]
        public async Task<IActionResult> Post([Validate]CreateConversationDTO createConversationDTO, int id)
        {
            var result = await _conversationService.Add(createConversationDTO, id);
            if(result > 0)
            {
                return Ok(new
                {
                    id = result
                });
            }
            return BadRequest("Wrong provided data");
        }

        // PUT api/<ConversationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreateConversationDTO createConversationDTO, int id)
        {
            var result = await _conversationService.Update(createConversationDTO, id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided data");
        }

        // DELETE api/<ConversationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _conversationService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong data id");
        }
    }
}
