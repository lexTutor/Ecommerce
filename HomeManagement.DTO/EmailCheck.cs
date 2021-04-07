using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class EmailCheck
    {
        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

        public ICollection<string> Emails { get; set; } = new List<string>();
    }
}
