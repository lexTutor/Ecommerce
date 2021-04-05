﻿namespace HomeManagement.Models
{
    public class UserTasks: BaseEntity
    {
        public string TaskId { get; set; }

        public Tasks Task { get; set; }

        public string    AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}