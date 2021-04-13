using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.DTO
{
    public class EditPersonalIssueDTO
    {
        public string Id{ get; set; }
        public string IssueImage { get; set; }

        [Required]
        public string IssueDetails { get; set; }

    }
}
