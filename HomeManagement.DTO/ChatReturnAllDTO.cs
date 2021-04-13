using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class ChatReturnAllDTO
    {
        public string ChatId { get; set; }
        public AppUser UserTo { get; set; }

        public string LastMessage { get; set; }

        public DateTime MessageTime { get; set; }
    }
}
