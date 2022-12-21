using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class OrderStatus
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Orders Order { get; set; }
    }
}
