using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Models
{
    public class Chats: BaseEntity
    {

        public ICollection<Messages> Message { get; set; }

        public AppUser UserTo { get; set; }

    }
}
