using HomeManagement.DTO;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Core.ServiceAbstractions
{
    public interface IPersonalIssueService
    {
        System.Threading.Tasks.Task<Response<ICollection<PersonalIssueReturnAllDTO>>> GetALLPersonalIssues(string userId);
        System.Threading.Tasks.Task<Response<PersonalIssueReturnDTO>> GetPersonalIssueById(string TaskIssueId);
        System.Threading.Tasks.Task<bool> DeletePersonalIssue(string TaskIssueId);
        System.Threading.Tasks.Task<bool> EditPersonalIssue(EditPersonalIssueDTO model);
        System.Threading.Tasks.Task<bool> MarkPersonalIssueAsResolved(string TaskIssueId);
        System.Threading.Tasks.Task<Response<PersonalIssueReturnDTO>> CreatePersonalIssue(CreatePersonalIssueDTO model);
    }
}
