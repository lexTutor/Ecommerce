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
    [Route("api/v1/HMA/Family/[controller]")]
    [Authorize]
    public class PersonalIssueController: ControllerBase
    {
        private readonly IPersonalIssueService _personalIssueService;

        public PersonalIssueController(IServiceProvider serviceProvider)
        {
            _personalIssueService = serviceProvider.GetRequiredService<IPersonalIssueService>();
        }

        [HttpGet]
        [Route("{taskId}")]
        public async Task<IActionResult> GetAllPersonalIssues(string taskId)
        {
            var result = await _personalIssueService.GetALLPersonalIssues(taskId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]/{issueId}")]
        public async Task<IActionResult> GetPersonalIssue(string issueId)
        {
            var result = await _personalIssueService.GetPersonalIssueById(issueId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePersonalIssue(CreatePersonalIssueDTO model)
        {
            var result = await _personalIssueService.CreatePersonalIssue(model);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPatch]
        [Route("{issueId}/[action]")]
        public async Task<IActionResult> EditPersonalIssue(EditPersonalIssueDTO model, string issueId)
        {
            model.Id = issueId;
            var result = await _personalIssueService.EditPersonalIssue(model);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPatch]
        [Route("{issueId}/MarkIssueAsResolved")]
        public async Task<IActionResult> MarkIssueAsResolved(string issueId)
        {
            var result = await _personalIssueService.MarkPersonalIssueAsResolved(issueId);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [Route("{issueId}/DeletePersonalIssue")]
        public async Task<IActionResult> DeletePersonalIssue(string issueId)
        {
            var result = await _personalIssueService.DeletePersonalIssue(issueId);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
