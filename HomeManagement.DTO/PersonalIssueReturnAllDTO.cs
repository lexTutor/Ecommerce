using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class PersonalIssueReturnAllDTO
    {
        public string IssueImage { get; set; }

        public AppUser IssueFrom { get; set; }

        public string IssueDetails { get; set; }
    }
}
