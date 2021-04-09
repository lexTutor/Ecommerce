using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services.Repositories
{
    public class TaskIssueRepository: GenericRepository<TaskIssue>, ITaskIssueRepository
    {
        private readonly DataContext _ctx;
        public TaskIssueRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<TaskIssue>> GetAllIssuesForATask(string taskId)
        {
            var result = await _ctx.TaskIssues.Include(issue=> issue.IssueWith).
                Where(issue => issue.IssueWith.Id == taskId).ToListAsync();
            return result;
        }

        public async Task<TaskIssue> GetTaskIsssue(string TasIssuekId)
        {
            var result = await _ctx.TaskIssues.Include(issue => issue.IssueFrom).Include(issue => issue.IssueWith)
                .Include(issue => issue.Reactions).FirstOrDefaultAsync(issue => issue.Id == TasIssuekId);
            return result;
        }
    }
}
