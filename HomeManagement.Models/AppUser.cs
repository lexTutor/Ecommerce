using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeManagement.Models
{
    public class AppUser: IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public string CountryOfOrigin { get; set; }

        public string CountryOfResidence { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Street { get; set; }

        public Family Family { get; set; }

        public ICollection<UserTasks> Tasks { get; set; }

        public ICollection<Chat> Messages { get; set; }

        public ICollection<PersonalIssue> PersonalIssues { get; set; }

        public ICollection<Reaction> Reactions { get; set; }

    }
}
