using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class BackendMenuDetails
    {
        public Guid Id { get; set; }
        public Guid BackendMenuId { get; set; }
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int SequenceOrder { get; set; }

        public virtual BackendMenus BackendMenu { get; set; }
    }
}
