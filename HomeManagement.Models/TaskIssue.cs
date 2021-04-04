using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.Models
{
    public class TaskIssue
    {
        public string TaskIssueId { get; set; }

        public string IssueImage { get; set; }

        [Required]
        public AppUser IssueFrom { get; set; }

        [Required]
        public string IssueDetails { get; set; }

        [Required]
        public Tasks IssueWith { get; set; }

        public Reactions Reactions { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }
    }
}
