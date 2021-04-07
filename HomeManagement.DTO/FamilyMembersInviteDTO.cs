using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.DTO
{
    public class FamilyMembersInviteDTO
    {
        [Required]
        public IEnumerable<string> Emails { get; set; }
    }
}
