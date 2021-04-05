using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManagement.Models
{
    public class PersonalIssue: BaseEntity
    {

        public string IssueImage { get; set; }

        [Required]
        public AppUser IssueFrom { get; set; }

        [Required]
        public string IssueDetails { get; set; }

        public Reactions Reactions { get; set; }

        [Required]
        public  DateTime  IssueDate { get; set; }
    }
}