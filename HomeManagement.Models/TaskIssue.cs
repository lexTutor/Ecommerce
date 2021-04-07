using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.Models
{
    public class TaskIssue: BaseEntity
    {
        public string IssueImage { get; set; }

        [Required]
        public AppUser IssueFrom { get; set; }

        [Required]
        public string IssueDetails { get; set; }

        [Required]
        public Task IssueWith { get; set; }

        public Reaction Reactions { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }
    }
}
