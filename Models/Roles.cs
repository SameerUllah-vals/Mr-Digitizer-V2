using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RoleBackendMenus = new HashSet<RoleBackendMenus>();
            Users = new HashSet<Users>();
        }

        public Guid Id { get; set; }
        public Guid? SubscriptionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public DateTime UtccreatedDateTime { get; set; }
        public DateTime? UtcupdatedDateTime { get; set; }
        public DateTime? UtcdeletedDateTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }

        public virtual ICollection<RoleBackendMenus> RoleBackendMenus { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
