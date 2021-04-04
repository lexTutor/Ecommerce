using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Models.ViewModels
{
    public class SendInviteVM
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; } = new Random(456).Next(893, 777867).ToString();
        public string InviteType { get; set; }
    }
}
