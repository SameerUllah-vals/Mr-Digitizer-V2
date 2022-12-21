using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class OrderDocuments
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid? UserId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Users User { get; set; }
    }
}
