using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class RoleBackendMenus
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid MenuId { get; set; }
        public string Permission { get; set; }
        public int Position { get; set; }

        public virtual BackendMenus Menu { get; set; }
        public virtual Roles Role { get; set; }
    }
}
