using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.DTO.ManualMapper
{
    public class DTOMappings
    {
        public static Models.Task MapToTask(CreateTaskDTO model, AppUser user)
        {
            var task = new Models.Task
            {
                CreatedAt = DateTime.Now,
                TaskCreator = user,
                TaskDetails = model.TaskDetails,
                TaskDueDate = model.TaskDueDate,
                TaskType = model.TaskType,
                ImagePath = model.ImagePath
            };

            task.TaskAsignees = GetAssignees(model.TaskAsignees, task.Id);
            return task;
        }

        private static ICollection<UserTasks> GetAssignees(ICollection<string> taskAsignees, string taskId)
        {
            var assignees = new List<UserTasks>();
            foreach (var assignee in taskAsignees)
            {
                assignees.Add(new UserTasks
                {
                    AppUserId = assignee,
                    TaskId = taskId
                });
            }

            return assignees;
        }
    }
}
