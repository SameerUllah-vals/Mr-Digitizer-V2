using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class BackendMenus
    {
        public BackendMenus()
        {
            BackendMenuDetails = new HashSet<BackendMenuDetails>();
            InverseParent = new HashSet<BackendMenus>();
            RoleBackendMenus = new HashSet<RoleBackendMenus>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? PackageId { get; set; }
        public string Type { get; set; }
        public bool? IsDefault { get; set; }
        public string Title { get; set; }
        public string AccessUrl { get; set; }
        public string IconClass { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual BackendMenus Parent { get; set; }
        public virtual ICollection<BackendMenuDetails> BackendMenuDetails { get; set; }
        public virtual ICollection<BackendMenus> InverseParent { get; set; }
        public virtual ICollection<RoleBackendMenus> RoleBackendMenus { get; set; }
    }
}
