using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.AspNetCore.Http;
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
    [Route("api/v1/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;
        public TaskController(IServiceProvider serviceProvider)
        {
            _taskService = serviceProvider.GetRequiredService<ITaskService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }

        [HttpGet]
        [Route("GetAllTasksByFamily")]
        public async Task<IActionResult> GetAllTasksByFamily(string UserId)
        {
            var result =  await _taskService.GetAllTaskByFamily(UserId);
            if (!result.Success) return BadRequest();
            return Ok(result);
        }


        [HttpGet]
        [Route("{id}/GetTask", Name = "GetTask")]
        public async Task<IActionResult> GetTask(string id)
        {
            var result = await _taskService.GetTask(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> CreateTask(CreateTaskDTO model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _taskService.CreateTask(model, user);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtRoute(nameof(GetTask), new { Id = result.Data.Id }, result.Data);
        }

        [HttpPatch]
        [Route("EditTaskDescription")]
        public async Task<IActionResult> EditTaskDescription(EditTaskDTO model)
        {
            var result = await _taskService.EditTaskDescription(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPatch]
        [Route("AssignTask")]
        public async Task<IActionResult> AssignTask(EditAssigneeDTO model)
        {
            var result = await _taskService.AssignTask(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPatch]
        [Route("RemoveAssignee")]
        public async Task<IActionResult> RemoveAssignee(EditAssigneeDTO model)
        {
            var result = await _taskService.RemoveAssignee(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPatch]
        [Route("ChangeDeliveryDate")]
        public async Task<IActionResult> ChangeDeliveryDate(EditTaskDateDTO model)
        {
            var result = await _taskService.ChangeDeliveryDate(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPatch]
        [Route("SubmitTask")]
        public async Task<IActionResult> SubmitTask(EditAssigneeDTO model)
        {
            var result = await _taskService.SubmitTask(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}/DeleteTask")]
        public async Task<IActionResult> DeleteTask(string Id)
        {
            var result = await _taskService.DeleteTask(Id);
            if (!result)
                return BadRequest();
            return NoContent();
        }

    }
}
