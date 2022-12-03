using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Areas = new HashSet<Areas>();
            Cities = new HashSet<Cities>();
            States = new HashSet<States>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string CodePhoneNumber { get; set; }
        public string AccessUrl { get; set; }
        public string IconImage { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
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

        public virtual ICollection<Areas> Areas { get; set; }
        public virtual ICollection<Cities> Cities { get; set; }
        public virtual ICollection<States> States { get; set; }
    }
}
