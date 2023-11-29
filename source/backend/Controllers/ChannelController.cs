using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Core.Entities;
using Backend.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using O9d.AspNet.FluentValidation;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Authorize]
    [Route("api/channels")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;
        private readonly IUserService _userService;
        public ChannelController(IChannelService channelService, IUserService userService)
        {
            _channelService = channelService;
            _userService = userService;
        }
        // GET: api/<ChannelController>
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet("{channelId}")]
        public async Task<IActionResult> Get(int channelId)
        {
            var result = await _channelService.Get(channelId);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        // POST api/<ChannelController>
        [HttpPost]
        public async Task<IActionResult> Post([Validate]CreateChannelDTO createChannelDTO)
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userService.GetAsync(username);
            try
            {
                var result = await _channelService.Add(createChannelDTO, (int)user.Id);
                if(result != null)
                {
                    return Created("", result);
                }
                return BadRequest("Wrong provided data");
            } catch (MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 1062:
                        return Conflict("Duplicate entry");
                    default:
                        return StatusCode(500, "Internal Server Error");
                }
            }
        }
        // PUT api/<ChannelController>/5
        [HttpPut("{channelId}")]
        public async Task<IActionResult> Put(int channelId, [Validate]UpdateChannelDTO updateChannelDTO)
        {
            var result = await _channelService.Update(updateChannelDTO, channelId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Wrong provided info");
        }

        // DELETE api/<ChannelController>/5
        [HttpDelete("{channelId}")]
        public async Task<IActionResult> Delete(int channelId)
        {
            var result = await _channelService.Delete(channelId);
            if (result)
            {
                return NoContent();
            }
            return BadRequest("Wrong provided id");
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet("requests")]
        public async Task<IActionResult> GetRequests()
        {
            var result = await _channelService.GetRequests();
            if (result != null && result.Count != 0)
            {
                return Ok(result);
            }
            return NoContent();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost("requests/{requestId}")]
        public async Task<IActionResult> Approve(int requestId)
        {
            var result = await _channelService.ApproveRequest(requestId);
            if (result != null)
            {
                return Created("", result);
            }
            return BadRequest("Wrong provided id");
        }
    }
}
