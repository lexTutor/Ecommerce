using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Controllers
{
    [Route("/api/v1/HMA/Family/User/[controller]")]
    [ApiController]
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
