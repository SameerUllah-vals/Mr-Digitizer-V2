using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string ConnectionId { get; set; }
        public string Fullname { get; set; }
        public string ProfileImagePath { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PasswordRecoveryCode { get; set; }
        public DateTime? PasswordRecoveryExpireDateTime { get; set; }
        public DateTime? VerificationDateTime { get; set; }
        public string Status { get; set; }
        public string AccountType { get; set; }
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

        public virtual Roles Role { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
