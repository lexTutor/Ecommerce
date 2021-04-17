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
    [ApiController]
    [Route("api/HMA/v1/Family/[controller]/[action]")]
    [Authorize]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService _reactionService;
        private readonly UserManager<AppUser> _userManager;
        public ReactionController(IServiceProvider serviceProvider)
        {
            _reactionService = serviceProvider.GetRequiredService<IReactionService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }

        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> SendReaction(AddReactionDTO model, string Id)
        {
            var result = await _reactionService.AddReaction(model, Id);
            if (!result.Success)
                return BadRequest();
            return Ok(result);  //change to CreatedAt if need be
        }

        [HttpPatch]
        [Route("{reactionId}")]
        public async Task<IActionResult> EditReaction(string emoji, string reactionId)
        {
            var result = await _reactionService.EditReaction(emoji, reactionId);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]
        [Route("{reactionId}")]
        public async Task<IActionResult> DeleteReaction(string reactionId)
        {
            var result = await _reactionService.DeleteReaction(reactionId);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
