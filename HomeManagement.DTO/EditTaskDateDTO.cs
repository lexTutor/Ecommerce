using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO
{
    public class EditTaskDateDTO
    {
        public string TaskId { get; set; }

        public DateTime NewDeliveryDate { get; set; }
    }
}
