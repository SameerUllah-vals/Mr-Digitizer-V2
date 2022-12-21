using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDocuments = new HashSet<OrderDocuments>();
            OrderStatus = new HashSet<OrderStatus>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? DeisgnerId { get; set; }
        public string DesignName { get; set; }
        public string OrderType { get; set; }
        public string Fabric { get; set; }
        public string Placement { get; set; }
        public string Format { get; set; }
        public string NoOfColors { get; set; }
        public string ColorType { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrderDocuments> OrderDocuments { get; set; }
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }
    }
}
