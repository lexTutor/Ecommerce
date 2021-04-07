using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Services.Repositories
{
    public class TaskIssueRepository: GenericRepository<TaskIssue>, ITaskIssueRepository
    {
        private readonly DataContext _ctx;
        public TaskIssueRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
