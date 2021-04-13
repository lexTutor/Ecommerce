using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Controllers
{
    [ApiController]
    [Route("api/v1/HMA/Family/Chat")]
    public class MessageController: ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;
        public MessageController(IServiceProvider serviceProvider)
        {
            _messageService = serviceProvider.GetRequiredService<IMessageService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }

        [HttpPost]
        [Route("{chatId}")]
        public async Task<IActionResult> SendMessage(CreateMessageDTO model, string chatId)
        {
            var result = await _messageService.CreateMessage(model, chatId);
            if (!result.Success)
                return BadRequest();
            return Ok(result);  //change to createdAt if need be
        }

        [HttpPatch]
        [Route("[controller]/{messageId}")]
        public async Task<IActionResult> EditMessage(EditMessageDTO model, string messageId)
        {
            var result = await _messageService.EditMessage(model, messageId);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]
        [Route("[controller]/{messageId}")]
        public async Task<IActionResult> DeleteMessage(string messageId)
        {
            var result = await _messageService.DeleteMessage(messageId);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
