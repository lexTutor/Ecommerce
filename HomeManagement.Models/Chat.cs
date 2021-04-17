using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeManagement.Models
{
    public class Chat : BaseEntity
    {
        [Required]
        public string UserFromId { get; set; }

        [Required]
        public string UserToId { get; set; }
        public ICollection<Message> Message { get; set; }

        public virtual AppUser UserFrom { get; set; }
        public virtual AppUser UserTo { get; set; }

    }
}
