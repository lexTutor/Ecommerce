using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Controllers
{
    [ApiController]
    [Route("api/HMA/v1/Family/[controller]/[action]")]
    [Authorize]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var result = await _userService.GetUser(userId);
            if (!result.Success)
                return BadRequest();
            return Ok(result);
        }

        /// <summary>
        /// Edits a user's details
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> Edit(UserDTO model, string userId)
        {
            var result = await _userService.EditUser(model, userId);
            if (!result)
                return BadRequest(result);
            return Ok();
        }

        /// <summary>
        /// LogIn a user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/Home/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            LoginDTO model = new LoginDTO { EmailAddress = email, Password = password };
            var result = await _userService.Login(model);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            var result = await _userService.DeleteUser(userId);
            if (!result)
                return BadRequest(result);
            return Ok();
        }
    }
}
