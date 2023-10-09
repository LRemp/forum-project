using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using O9d.AspNet.FluentValidation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Route("api/channels/{channelId}/conversations")]
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
            var result = await _conversationService.Add(createConversationDTO, channelId);
            if (result > 0)
            {
                return Ok(new
                {
                    id = result
                });
            }
            return BadRequest("Wrong provided data");
        }

        // PUT api/<ConversationController>/5
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
        [HttpDelete("{conversationId}")]
        public async Task<IActionResult> Delete(int channelId, int conversationId)
        {
            var result = await _conversationService.Delete(channelId, conversationId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong data id");
        }
    }
}
