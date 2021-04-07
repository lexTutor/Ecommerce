using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Services.Repositories
{
    public class TaskRepository: GenericRepository<Task>, ITaskRepository
    {
        private readonly DataContext _ctx;
        public TaskRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
