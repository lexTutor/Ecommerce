using AutoMapper;
using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.DTO.ManualMapper;
using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public TaskService(IServiceProvider serviceProvider)
        {
            _taskRepository = serviceProvider.GetRequiredService<ITaskRepository>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        public async Task<bool> AssignTask(EditAssigneeDTO model)
        {
            var task = await _taskRepository.GetDetailedTaskByID(model.TaskId);
            var user = await _userManager.FindByIdAsync(model.UserId);
            var isFamily = task.TaskCreator.Family.Id == user.Family.Id;
            if (task == null || user == null || !isFamily)
                return false;
            task.TaskAsignees.Add(new UserTasks 
            {
                AppUserId = model.UserId,
                TaskId = model.TaskId,
                AppUser = user,
                Task = task
            });
            return await _taskRepository.Modify(task);
        }

        public async Task<bool> ChangeDeliveryDate(EditTaskDateDTO model)
        {
            var task = await _taskRepository.GetById(model.TaskId);
            if (task != null)
            {
                task.TaskDueDate = model.NewDeliveryDate != null? model.NewDeliveryDate: task.TaskDueDate;
                return await _taskRepository.Modify(task);
            }
            return false;
        }

        public async Task<Response<TaskReturnDTO>> CreateTask(CreateTaskDTO model, AppUser user)
        {
            var newTask = DTOMappings.MapToTask(model, user);
            var result = await _taskRepository.Add(newTask);
            if (!result)
                return new Response<TaskReturnDTO>
                {
                    Message = "Task not Created successfully",
                    Success = false
                };
            return new Response<TaskReturnDTO>
            {
                Data = _mapper.Map<TaskReturnDTO>(newTask),
                Success = true,
                Message = "Task Created successfully"
            };
        }

        public Task<bool> DeleteTask(string Id)
        {
          return _taskRepository.DeleteById(Id);
        }

        public async Task<bool> EditTaskDescription(EditTaskDTO model)
        {
            var task = await _taskRepository.GetById(model.TaskId);
            if (task != null)
            {
                task.TaskDetails = string.IsNullOrWhiteSpace(model.TaskDetails) ? task.TaskDetails : model.TaskDetails;
                task.TaskType = string.IsNullOrWhiteSpace(model.TaskDetails) ? task.TaskType : model.TaskType;

                return await _taskRepository.Modify(task);
            }
            return false;
        }

        public async Task<Response<ICollection<TaskReturnAllDTO>>> GetAllTaskByFamily(string userId, string familyId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user.FamilyId == familyId)
            {
                var result = await _taskRepository.GetAllFamilyTasks(user.Family.Id);
                if (result == null)
                    return new Response<ICollection<TaskReturnAllDTO>>
                    {
                        Success = false
                    };
            return new Response<ICollection<TaskReturnAllDTO>>
            {
                Data = _mapper.Map<List<TaskReturnAllDTO>>(result),
                Message = "Tasks",
                Success = true
            };
            }
            return new Response<ICollection<TaskReturnAllDTO>>
            {
                Success = false
            };
        }

        public async Task<Response<TaskReturnDTO>> GetTask(string Id)
        {
           var task = await _taskRepository.GetDetailedTaskByID(Id);
            if (task == null)
                return new Response<TaskReturnDTO>
                {
                    Success = false,
                    Message = "No task with such Id"
                };
            return new Response<TaskReturnDTO>
            {
                Data = _mapper.Map<TaskReturnDTO>(task),
                Success = true
            };
        }

        public async Task<bool> RemoveAssignee(EditAssigneeDTO model)
        {
            var task = await _taskRepository.GetDetailedTaskByID(model.TaskId);
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (task == null || user == null)
                return false;
            var asigneeToRemove = task.TaskAsignees.FirstOrDefault(task => task.AppUserId == model.UserId);
            task.TaskAsignees.Remove(asigneeToRemove);
            return await _taskRepository.Modify(task);
        }

        public async Task<bool> SubmitTask(EditAssigneeDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return false;
           var taskToSubmit = user.Tasks.FirstOrDefault(Task => Task.TaskId == model.TaskId);
            if (taskToSubmit == null)
                return false;
            taskToSubmit.IsCompleted = true;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
