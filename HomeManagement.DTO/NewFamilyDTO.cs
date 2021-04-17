using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.DTO
{
    public class NewFamilyDTO
    {
        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public int FamilySize { get; set; }

        [Required]
        public string Password { get; set; }

        public string  EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
