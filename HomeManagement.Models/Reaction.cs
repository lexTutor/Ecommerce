using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.Models
{
    public class Reaction: BaseEntity
    {
        public string Emoji { get; set; }

        [Required]
        public AppUser User { get; set; }
        public string UserId { get; set; }

        public Task Task { get; set; }
        public string TaskId { get; set; }

        public Message Message { get; set; }
        public string MessageId { get; set; }
    }
}
