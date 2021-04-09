using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class TaskReturnAllDTO
    {
        public string Id { get; set; }
        public string TaskDetails { get; set; }

        public AppUser TaskCreator { get; set; }

        public string TaskType { get; set; }

        public string ImagePath { get; set; }

        public DateTime TaskCreationDate { get; set; }
        public DateTime TaskDueDate { get; set; }
    }
}
