using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.Models.ViewModels
{
    public class UpdateInfoVM
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]

        public string UserName { get; set; }

        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }

        [Required]

        public string EmailAddress { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string ParentalRole { get; set; }

        public string CountryOfOrigin { get; set; }

        public string CountryOfResidence { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Street { get; set; }

        [Required]
        public DateTime DOBB { get; set; }
    }
}
