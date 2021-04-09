using HomeManagement.DTO;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.ServiceAbstractions
{
    public interface ITaskService
    {
        Task<Response<ICollection<TaskReturnAllDTO>>> GetAllTaskByFamily(string UserId);

        Task<Response<TaskReturnDTO>> GetTask(string Id);

        Task<bool> DeleteTask(string Id);

        Task<Response<TaskReturnDTO>> CreateTask(CreateTaskDTO model, AppUser user);

        Task<bool> EditTaskDescription(EditTaskDTO model);

        Task<bool> AssignTask(EditAssigneeDTO model);

        Task<bool> RemoveAssignee(EditAssigneeDTO model);

        Task<bool> ChangeDeliveryDate(EditTaskDateDTO model);

        Task<bool> SubmitTask(EditAssigneeDTO model);
    }
}
