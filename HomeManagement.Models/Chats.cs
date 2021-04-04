using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Models
{
    public class Chats
    {
        public string ChatsId { get; set; }

        public ICollection<Messages> Message { get; set; }

        public ICollection<Reactions> Reactions { get; set; }

        public AppUser Users { get; set; }

        public string To { get; set; }

        public string From { get; set; }
    }
}
