using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class CreateMessageDTO
    {
        public string  MessageDetails { get; set; }

        public IFormFile  Attachment { get; set; }
    }
}
