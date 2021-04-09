using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class TaskReturnDTO
    {
        public string Id { get; set; }
        public string TaskDetails { get; set; }

        public AppUser TaskCreator { get; set; }

        public bool Completed { get; set; }

        public string TaskType { get; set; }

        public ICollection<TaskIssue> Issues { get; set; }

        public ICollection<UserTasks> TaskAsignees { get; set; }

        public ICollection<Reaction> Reactions { get; set; }

        public string ImagePath { get; set; }

        public DateTime TaskCreationDate { get; set; }
        public DateTime TaskDueDate { get; set; }
    }
}
