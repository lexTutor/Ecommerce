using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.Models
{
    public class Reaction: BaseEntity
    {
        public string ReactionsId { get; set; }
        public string Emoji { get; set; }

        [Required]
        public AppUser UserWhoReacted { get; set; }

        public Task Task { get; set; }

        public Chat Chat { get; set; }
    }
}
