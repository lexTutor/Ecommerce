using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeManagement.Models
{
    public class Messages: BaseEntity
    {

        [Required]
        public Chats Chat { get; set; }
        public string Attachment { get; set; }

        [Required]
        public string MessageDetails { get; set; }
        public ICollection<Reactions> Reactions { get; set; }

        [Required]
        public DateTime MessageDate { get; set; }
    }
}