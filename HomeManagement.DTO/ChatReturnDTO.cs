using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class ChatReturnDTO
    {
        public string Id { get; set; }
        public ICollection<Message> Message { get; set; }

        public AppUser UserTo { get; set; }
    }
}
