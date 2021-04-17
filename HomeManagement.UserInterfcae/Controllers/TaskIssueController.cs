using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Controllers
{
    [ApiController]
    [Route("api/HMA/v1/Family/Task/[controller]")]
    [Authorize]
    public class TaskIssueController : ControllerBase
    {
        private readonly ITaskIssueService _taskIssueService;

        public TaskIssueController(IServiceProvider serviceProvider)
        {
            _taskIssueService = serviceProvider.GetRequiredService<ITaskIssueService>();
        }
       
        [HttpGet]
        [Route("{taskId}")]
        public async Task<IActionResult> GetAllTaskIssues(string taskId)
        {
            var result = await _taskIssueService.GetALLTaskIssues(taskId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]/{taskIssueId}")]
        public async Task<IActionResult> GetTaskIssue(string taskIssueId)
        {
            var result = await _taskIssueService.GetTaskIssueById(taskIssueId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskIssue(CreateTaskIssueDTO model)
        {
            var result = await _taskIssueService.CreateTaskIssue(model);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPatch]
        [Route("[action]/{taskIssueId}")]
        public async Task<IActionResult> EditTaskIssue(EditTaskIssueDTO model, string taskIssueId)
        {
            model.TaskIssueId = taskIssueId;
            var result = await _taskIssueService.EditTaskIssue(model);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPatch]
        [Route("[action]/{taskIssueId}")]
        public async Task<IActionResult> MarkIssueAsResolved(string taskIssueId)
        {
            var result = await _taskIssueService.MarkIssueAsResolved(taskIssueId);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [Route("[action]/{taskIssueId}")]
        public async Task<IActionResult> DeleteTaskIssue(string taskIssueId)
        {
            var result = await _taskIssueService.DeleteTaskIssue(taskIssueId);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
