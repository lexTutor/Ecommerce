using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class TokenReturn
    {
        public Dictionary<AppUser, string> UserAndPassword { get; set; } = new Dictionary<AppUser, string>();

        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
    }
}
