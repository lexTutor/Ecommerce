using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.DTO
{
    public class CreateTaskDTO
    {
        [Required]
        public string TaskDetails { get; set; }

        public AppUser TaskCreator { get; set; }

        public string TaskType { get; set; }

        public ICollection<string> TaskAsignees { get; set; }

        public string ImagePath { get; set; }

        public DateTime TaskDueDate { get; set; }
    }
}
