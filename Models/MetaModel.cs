using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MrDigitizerV2.Models
{

    public class BreadCrumbMenu
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string AccessURL { get; set; }
    }
    public class LoginModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter your e-mail")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public string Role { get; set; }
        public string ReturnUrl { get; set; }
        public string RememberMe { get; set; }

        public string LoginWith { get; set; } = "web";
    }
    public class MemberModel
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public Guid CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
    public class MemberLoginModel
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class MemberForgotPasswordModel
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string EmailAddress { get; set; }
    }
    public class MemberResetModel
    {
        public string ResetToken { get; set; }
        public string ErrorMessage { get; set; }

        [Required(ErrorMessage = "Required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Required")]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }

    public partial class MembersMeta
    {

        [Required(ErrorMessage = "this field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    [ModelMetadataType(typeof(MembersMeta))]
    public partial class Members
    {
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [NotMapped]

        public Guid CountryId { get; set; }
        [NotMapped]

        public Guid StateId { get; set; }
    }

    public class OrdersMeta
    {
        [Required(ErrorMessage = "this field is required")]
        public string DesignName { get; set; }
        [Required(ErrorMessage = "this field is required")]

        public string OrderType { get; set; }
        [Required(ErrorMessage = "this field is required")]

        public string Format { get; set; }
        [Required(ErrorMessage = "this field is required")]

        public string NoOfColors { get; set; }
    }

    [ModelMetadataType(typeof(OrdersMeta))]
    public partial class Orders
    {
        [NotMapped]
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();

    }


    public class UserMeta
    {
        [Required(ErrorMessage ="this field is required")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    [ModelMetadataType(typeof(UserMeta))]
    public partial class Users
    {
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }

    public class EmailMeta : Orders
    {
        public string Fullname { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string URL { get; set; }
        public string WebsiteURL { get; set; }
        public double Rate { get; set; }
        public int Qty { get; set; }
        public string OrderURL { get; set; }
        public List<string> Attachements { get; set; } = new List<string>();
    }

}
