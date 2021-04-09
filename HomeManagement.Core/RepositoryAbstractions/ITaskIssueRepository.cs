using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.RepositoryAbstractions
{
    public interface ITaskIssueRepository : IGenericRepository<TaskIssue>
    {
        Task<TaskIssue> GetTaskIsssue(string TasIssuekId);

        Task<ICollection<TaskIssue>> GetAllIssuesForATask(string TaskId);
    }
}
