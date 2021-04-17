using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Controllers
{
    [ApiController]
    [Route("api/HMA/v1/Family")]
    [Authorize]
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
        [Route("{familyId}/[action]")]
        public async Task<IActionResult> Tasks(string familyId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result =  await _taskService.GetAllTaskByFamily(user.Id, familyId);
            if (!result.Success) return BadRequest();
            return Ok(result);
        }


        [HttpGet]
        [Route("[controller]/{taskId}", Name = "GetTask")]
        public async Task<IActionResult> GetTask(string taskId)
        {
            var result = await _taskService.GetTask(taskId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = Policies.Policies.Parent)]
        [Authorize(Policy = Policies.Policies.Guardian)]
        public async Task<IActionResult> CreateTask(CreateTaskDTO model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _taskService.CreateTask(model, user);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtRoute(nameof(GetTask), new { Id = result.Data.Id }, result.Data);
        }

        [HttpPatch]
        [Route("[action]/{taskId}")]
        [Authorize(Policy = Policies.Policies.Parent)]
        [Authorize(Policy = Policies.Policies.Guardian)]
        public async Task<IActionResult> EditTaskDescription(EditTaskDTO model, string taskId)
        {
            model.TaskId = taskId;
            var result = await _taskService.EditTaskDescription(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPatch]
        [Route("[controller]/[action]/{taskId}")]
        [Authorize(Policy = Policies.Policies.Parent)]
        [Authorize(Policy = Policies.Policies.Guardian)]
        public async Task<IActionResult> AssignTask(EditAssigneeDTO model, string taskId)
        {
            model.TaskId = taskId;
            var result = await _taskService.AssignTask(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPatch]
        [Route("[controller]/[action]/{taskId}")]
        [Authorize(Policy = Policies.Policies.Parent)]
        [Authorize(Policy = Policies.Policies.Guardian)]
        public async Task<IActionResult> RemoveAssignee(EditAssigneeDTO model, string taskId)
        {
            model.TaskId = taskId;
            var result = await _taskService.RemoveAssignee(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPatch]
        [Route("[controller]/[action]/{taskId}")]
        [Authorize(Policy = Policies.Policies.Parent)]
        [Authorize(Policy = Policies.Policies.Guardian)]
        public async Task<IActionResult> ChangeDeliveryDate(EditTaskDateDTO model, string taskId)
        {
            model.TaskId = taskId;
            var result = await _taskService.ChangeDeliveryDate(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPatch]
        [Route("[controller]/[action]/{taskId}")]
        public async Task<IActionResult> SubmitTask(EditAssigneeDTO model, string taskId)
        {
            model.TaskId = taskId;
            var result = await _taskService.SubmitTask(model);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]

        [Route("[action]/{id}")]
        [Authorize(Policy = Policies.Policies.Parent)]
        [Authorize(Policy = Policies.Policies.Guardian)]
        public async Task<IActionResult> DeleteTask(string Id)
        {
            var result = await _taskService.DeleteTask(Id);
            if (!result)
                return BadRequest();
            return NoContent();
        }

    }
}
