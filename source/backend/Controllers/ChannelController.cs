using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;
        public ChannelController(IChannelService channelService)
        {
            _channelService = channelService;
        }
        // GET: api/<ChannelController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _channelService.Get();
            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }
            return NoContent();
        }

        // GET api/<ChannelController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _channelService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        // POST api/<ChannelController>
        [HttpPost]
        public async Task<IActionResult> Post(ChannelDTO channelDTO)
        {
            var result = await _channelService.Add(channelDTO);
            if(result != null)
            {
                return Created("", result);
            }
            return BadRequest("Wrong provided data");
        }

        // PUT api/<ChannelController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ChannelDTO channelDTO, int id)
        {
            var result = await _channelService.Update(channelDTO, id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided info");
        }

        // DELETE api/<ChannelController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _channelService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided id");
        }
    }
}
