using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Models
{
    public class Chat: BaseEntity
    {

        public ICollection<Message> Message { get; set; }

        public AppUser UserTo { get; set; }

    }
}
