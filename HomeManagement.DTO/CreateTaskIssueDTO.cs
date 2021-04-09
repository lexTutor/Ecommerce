using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class CreateTaskIssueDTO
    {
        public string IssueImage { get; set; }
        public string IssueDetails { get; set; }
        public string TaskId { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
