﻿using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class TaskIssueReturnDTO
    {
        public string Id { get; set; }
        public string IssueImage { get; set; }
        public AppUser IssueFrom { get; set; }
        public string IssueDetails { get; set; }
        public Task IssueWith { get; set; }

        public Reaction Reactions { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
