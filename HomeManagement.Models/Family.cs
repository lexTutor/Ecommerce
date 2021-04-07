using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Models
{
    public class Family: BaseEntity
    {
        public string FamilyName { get; set; }

        public ICollection<AppUser> FamilyMembers { get; set; }
    }
}