using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.DTO
{
    public class CreatePersonalIssueDTO
    { 
        public string IssueImage { get; set; }

        [Required]
        public AppUser IssueFrom { get; set; }

        [Required]
        public string IssueDetails { get; set; }

    }
}
