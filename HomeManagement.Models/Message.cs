using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeManagement.Models
{
    public class Message: BaseEntity
    {
        [Required]
        public Chat Chat { get; set; }
        public string ChatId { get; set; }

        public string Attachment { get; set; }

        [Required]
        public string MessageDetails { get; set; }
        public ICollection<Reaction> Reactions { get; set; }

        [Required]
        public DateTime MessageDate { get; set; }
    }
}