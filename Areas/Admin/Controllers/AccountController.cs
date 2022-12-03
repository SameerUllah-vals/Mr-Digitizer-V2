using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrDigitizerV2.Models;
using static MrDigitizerV2.Helpers.ApplicationHelper;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace MrDigitizerV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]

    public class AccountController : Controller
    {

        MrdigitizerV2Context Database;
        public AccountController()
        {
            Database = new MrdigitizerV2Context();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.WebsiteURL = GetSettingContentByName(Database, Website_URL_Key) + "Admin/";
            base.OnActionExecuting(filterContext);
        }

        public IActionResult Login(string ReturnUrl)
        {
            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                ViewBag.ReturnUrl = ReturnUrl;
            }

            if (!string.IsNullOrEmpty(GetCookie(this, Cookie_Admin_Area_Authentication)))
            {
                return Redirect(ViewBag.WebsiteURL + "dashboard/index");
            }
            return View(new LoginModel { });
        }


        [HttpPost]
        [Route("account/login")]
        public IActionResult Login([Bind] LoginModel user)
        {
            AjaxResponse AjaxResponse = new AjaxResponse();
            AjaxResponse.Success = false;
            AjaxResponse.Type = EnumJQueryResponseType.MessageOnly;
            AjaxResponse.Message = "Wrong email-address or password.";
            var users = new Users();
            string LoginEncryptPasswordValue = Encrypt(user.Password);
            var userRecord = Database.Users.FirstOrDefault(o => o.EmailAddress.Equals(user.EmailAddress) && o.Password.Equals(LoginEncryptPasswordValue) && o.IsDeleted == false && o.Status == EnumStatus.Enable );
            if (userRecord != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, userRecord.Id.ToString()),
                    new Claim(ClaimTypes.Role, userRecord.RoleId.ToString()),
                    new Claim(ClaimTypes.Name, userRecord.Fullname),
                    new Claim(ClaimTypes.Email, userRecord.EmailAddress),
                 };
                var Identity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { Identity });
                HttpContext.SignInAsync("scheme1", userPrincipal);
                AjaxResponse.Success = true;
                AjaxResponse.Message = "Login Successfull Redirecting...";
                AjaxResponse.Type = EnumJQueryResponseType.MessageAndRedirect;
                if (!string.IsNullOrEmpty(user.ReturnUrl)) AjaxResponse.TargetURL = user.ReturnUrl;
                else AjaxResponse.TargetURL = ViewBag.WebsiteURL + "dashboard";

            }
            return Json(AjaxResponse);
        }


        [Route("account/SignOut")]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("","admin");
        }
    }
}
