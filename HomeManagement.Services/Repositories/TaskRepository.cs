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
    public class TaskRepository: GenericRepository<Models.Task>, ITaskRepository
    {
        private readonly DataContext _ctx;
        public TaskRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Models.Task>> GetAllFamilyTasks(string familyId)
        {
            var result = await _ctx.Tasks.Include(task => task.TaskCreator).ThenInclude(user => user.Family).Where(task => task.TaskCreator.Family.Id == familyId).ToListAsync();
            return result;
        }

        public async Task<Models.Task> GetDetailedTaskByID(string familyId)
        {
            var result = await _ctx.Tasks.Include(task => task.TaskCreator).Include(task=> task.TaskAsignees).Include(task=> task.Reactions).
                Include(task=> task.TaskAsignees).
                FirstOrDefaultAsync(task => task.TaskCreator.Family.Id == familyId);
            return result;
        }

    }
}
