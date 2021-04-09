using AutoMapper;
using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services.Services
{
    public class TaskIssueServices : ITaskIssueService
    {
        private readonly ITaskIssueRepository _taskIssueRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskIssueServices(IServiceProvider serviceProvider)
        {
            _taskIssueRepository = serviceProvider.GetRequiredService<ITaskIssueRepository>();
            _taskRepository = serviceProvider.GetRequiredService<ITaskRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        public async Task<Response<TaskIssueReturnDTO>> CreateTaskIssue(CreateTaskIssueDTO model)
        {
            var newModel = _mapper.Map<TaskIssue>(model);
           var result = await _taskIssueRepository.Add(newModel);
            if (!result)
                return new Response<TaskIssueReturnDTO>
                {
                    Success = false,
                    Message = "Issue not created"
                };
            return new Response<TaskIssueReturnDTO>
            {
                Success = true,
                Data = _mapper.Map<TaskIssueReturnDTO>(newModel)
            };
        }

        public Task<bool> DeleteTaskIssue(string TaskIssueId)
        {
            return _taskIssueRepository.DeleteById(TaskIssueId);
        }

        public async Task<bool> EditTaskIssue(EditTaskIssueDTO model)
        {
            var task = await _taskIssueRepository.GetById(model.TaskIssueId);
            if (task != null) 
            {
                task.IssueDetails = string.IsNullOrWhiteSpace(model.IssueDetails) ? task.IssueDetails : model.IssueDetails;
                task.IssueImage = string.IsNullOrWhiteSpace(model.IssueImage) ? task.IssueImage : model.IssueImage;
                return await _taskIssueRepository.Modify(task);
            }
            return false;
        }

        public async Task<Response<ICollection<TaskIssueReturnAllDTO>>> GetALLTaskIssues(string taskId)
        {
            var task = _taskRepository.GetById(taskId);
            if(task == null)
            {
                return new Response<ICollection<TaskIssueReturnAllDTO>>
                {
                    Message = "Invalid Id",
                    Success = false
                };
            }
            var result = await _taskIssueRepository.GetAllIssuesForATask(taskId);
            if (result == null)
                return new Response<ICollection<TaskIssueReturnAllDTO>>
                {
                    Message = "No TaskIssues",
                    Success = true
                };
            return new Response<ICollection<TaskIssueReturnAllDTO>>
            {

                Data = _mapper.Map<ICollection<TaskIssueReturnAllDTO>> (result),
                Success = true
            };
        }

        public async Task<Response<TaskIssueReturnDTO>> GetTaskIssueById(string TaskIssueId)
        {
            var taskIssue = await _taskIssueRepository.GetTaskIsssue(TaskIssueId);
            if (taskIssue == null)
                return new Response<TaskIssueReturnDTO>
                {
                    Message = "Invalid Id",
                    Success = false
                };
            return new Response<TaskIssueReturnDTO>
            {

                Data = _mapper.Map<TaskIssueReturnDTO>(taskIssue),
                Success = true
            };
        }

        public async Task<bool> MarkIssueAsResolved(string TaskIssueId)
        {
            var taskIssue = await _taskIssueRepository.GetTaskIsssue(TaskIssueId);
            if (taskIssue != null)
            {
                taskIssue.IsResolved = true;
                return await _taskIssueRepository.Modify(taskIssue);
            }
            return false;

        }
    }
}
