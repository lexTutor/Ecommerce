using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeManagement.Models
{
    public class Messages
    {
        public string MessagesId { get; set; }

        [Required]
        public Chats Chat { get; set; }
        public string Attachment { get; set; }

        [Required]
        public string MessageDetails { get; set; }

        [Required]
        public DateTime MessageDate { get; set; }
    }
}