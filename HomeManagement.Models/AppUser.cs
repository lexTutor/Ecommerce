using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeManagement.Models
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string Role { get; set; }

        public string ImagePath { get; set; }

        public string CountryOfOrigin { get; set; }

        public string CountryOfResidence { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Street { get; set; }

        public string FamilyId { get; set; }

        public Family Family { get; set; }

        public ICollection<UserTasks> Tasks { get; set; }

        public ICollection<Chat> Chat { get; set; }

        public ICollection<PersonalIssue> PersonalIssues { get; set; }

        public ICollection<Reaction> Reactions { get; set; }

    }
}
