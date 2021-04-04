﻿using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManagement.Models
{
    public class Tasks
    {
        public string TasksId { get; set; }

        [Required]
        public string TaskDetails { get; set; }

        [Required]
        public AppUser TaskCreator { get; set; }

        public bool Returned { get; set; }

        public TaskType TaskType { get; set; }

        public ICollection<TaskIssue> Issues { get; set; }

        public ICollection<UserTasks> TaskAsignees { get; set; }

        public ICollection<Reactions> Reactions { get; set; }

        public string ImagePath { get; set; }

        public DateTime TaskCreationDate { get; set; }
    }
}