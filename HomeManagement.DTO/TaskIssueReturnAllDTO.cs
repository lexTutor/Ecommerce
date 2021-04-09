using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class TaskIssueReturnAllDTO
    {
        public string Id { get; set; }
        public string IssueImage { get; set; }
        public string IssueDetails { get; set; }
        public Reaction Reactions { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
