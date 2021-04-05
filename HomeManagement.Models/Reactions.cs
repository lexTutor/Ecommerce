using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.Models
{
    public class Reactions: BaseEntity
    {
        public string ReactionsId { get; set; }
        public string Emoji { get; set; }

        [Required]
        public AppUser UserWhoReacted { get; set; }

        public Tasks Task { get; set; }

        public Chats Chat { get; set; }
    }
}
