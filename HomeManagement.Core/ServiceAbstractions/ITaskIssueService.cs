using HomeManagement.DTO;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Core.ServiceAbstractions
{
    public interface ITaskIssueService
    {
        System.Threading.Tasks.Task<Response<ICollection<TaskIssueReturnAllDTO>>> GetALLTaskIssues(string TaskId);
        System.Threading.Tasks.Task<Response<TaskIssueReturnDTO>> GetTaskIssueById(string TaskIssueId);
        System.Threading.Tasks.Task<bool> DeleteTaskIssue(string TaskIssueId);
        System.Threading.Tasks.Task<bool> EditTaskIssue(EditTaskIssueDTO model);
        System.Threading.Tasks.Task<bool> MarkIssueAsResolved(string TaskIssueId);
        System.Threading.Tasks.Task<Response<TaskIssueReturnDTO>> CreateTaskIssue(CreateTaskIssueDTO model); 
    }
}
