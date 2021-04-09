using HomeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeManagement.Core.RepositoryAbstractions
{
    public interface ITaskRepository: IGenericRepository<Models.Task>
    {
        Task<ICollection<Models.Task>> GetAllFamilyTasks(string familyId);
        Task<Models.Task> GetDetailedTaskByID(string familyId);
    }
}
