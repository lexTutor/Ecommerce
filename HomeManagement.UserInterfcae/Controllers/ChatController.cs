using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Controllers
{
    [Route("/api/v1/HMA/Family/User/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly UserManager<AppUser> _userManager;
        public ChatController(IServiceProvider serviceProvider)
        {
            _chatService = serviceProvider.GetRequiredService<IChatService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }

        [HttpGet]
        public async Task<IActionResult> GetALLChats()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _chatService.GetAllChatsForAUser(user.Id);
            if (!result.Success)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChat(string userToId, CreateMessageDTO model)
        {
            var userFrom = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _chatService.CreateChat(userToId, userFrom.Id, model);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtRoute(nameof(GetChat), new { Id = result.Data.Id }, result.Data);
        }

        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetChat(string Id)
        {
            var result = await _chatService.GetChat(Id);
            if (!result.Success)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> DeleteChat(string Id)
        {
            var result = await _chatService.DeleteChat(Id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
