using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrDigitizerV2.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using static MrDigitizerV2.Helpers.ApplicationHelper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MrDigitizerV2.Areas.Admin.Controllers
{
    [Authorize(AuthenticationSchemes = "scheme1")]
    public class BaseController : Controller
    {
        public readonly MrdigitizerV2Context dbContext;
        public Users CurrentUserRecord;
        public Guid currentUserId { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid RoleId { get; set; }
        public BaseController()
        {
            dbContext = new MrdigitizerV2Context();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var user = HttpContext.User;
            //var auth = User.Identity.IsAuthenticated;
            currentUserId = string.IsNullOrEmpty(User.FindFirstValue(ClaimTypes.NameIdentifier)) ? Guid.Empty
                : Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            RoleId = string.IsNullOrEmpty(User.FindFirstValue(ClaimTypes.Role)) ? Guid.Empty
                : Guid.Parse(User.FindFirstValue(ClaimTypes.Role));
            ViewBag.UserRecord = dbContext.Users.FirstOrDefault(x => x.Id == currentUserId);
            var TodayDate = GetDateTime();
            ViewBag.WebsiteURL = GetSettingContentByName(dbContext, Website_URL_Key) + "admin/";
            ViewBag.jQuery_Date_Time_Format = jQuery_Date_Time_Format;
            ViewBag.jQuery_Date_Format = jQuery_Date_Format;
            ViewBag.Website_Date_Time_Format = Website_Date_Time_Format;
            ViewBag.Website_Date_Format = Website_Date_Format;
            if (filterContext.HttpContext.Request.Headers["x-requested-with"] != "XMLHttpRequest")
            {
                string[] requestURL = filterContext.HttpContext.Request.Path.ToString().Split('/');
                string controllerURL = requestURL[2].ToLower(); //
                if (!User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectResult("/admin");
                }
                else
                {
                    //ViewBag.ControllerName = UpperCaseWords(controllerURL);
                    ViewBag.ControllerName = controllerURL.ToUpper();
                    ViewBag.ControllerURL = controllerURL;
                    string menuURL = controllerURL;
                    string actionURL = string.Empty;
                    if (requestURL.Length > 3) //
                    {
                        actionURL = requestURL[3].ToLower(); //
                        if (actionURL != "importexcel" && actionURL != "exportempty" && actionURL != "export" && actionURL != "add" && actionURL != "edit" && actionURL != "views" && actionURL != "sorting")
                        {
                            menuURL += "/" + actionURL;
                        }
                    }
                    //EmployerUsers userCurrentRecord = Database.EmployerUsers.FirstOrDefault(x => x.Id == currentUserId);
                    //ViewBag.ProfileImage = userCurrentRecord.ProfileImage == null ? "1.png" : userCurrentRecord.ProfileImage;
                    var UserRolePermissionRecords = dbContext.RoleBackendMenus.Where(o => o.RoleId == RoleId).OrderBy(o => o.Position).ToList();

                    if (!AllowedUrlList().Contains(menuURL))
                    {
                        filterContext.Result = new RedirectResult(WebsiteURL + "home/accessunauthorized");
                        if (UserRolePermissionRecords.Count > 0)
                        {
                            var UserRolePermissionRecord = UserRolePermissionRecords.FirstOrDefault(o => o.Menu.AccessUrl.ToLower().Equals(menuURL.Split("/").FirstOrDefault()));
                            if (UserRolePermissionRecord != null)
                            {
                                if (UserRolePermissionRecord.Permission.ToLower().Equals("all"))
                                {
                                    filterContext.Result = null;
                                    if (UserRolePermissionRecord.Menu.BackendMenuDetails.Any(o => o.Name.ToLower().Equals("add")))
                                    {
                                        ViewBag.AllowAdding = true;
                                    }
                                    if (UserRolePermissionRecord.Menu.BackendMenuDetails.Any(o => o.Name.ToLower().Equals("edit")))
                                    {
                                        ViewBag.AllowEditing = true;
                                    }
                                    if (UserRolePermissionRecord.Menu.BackendMenuDetails.Any(o => o.Name.ToLower().Equals("delete")))
                                    {
                                        ViewBag.AllowDeleting = true;
                                    }
                                    if (UserRolePermissionRecord.Menu.BackendMenuDetails.Any(o => o.Name.ToLower().Equals("view")))
                                    {
                                        ViewBag.AllowViewing = true;
                                    }
                                    if (UserRolePermissionRecord.Menu.BackendMenuDetails.Any(o => o.Name.ToLower().Equals("sorting")))
                                    {
                                        ViewBag.AllowSorting = true;
                                    }

                                }
                                else
                                {
                                    string[] UserPermissionArray = UserRolePermissionRecord.Permission.ToLower().Split('|');
                                    if (string.IsNullOrWhiteSpace(actionURL) || UserPermissionArray.Contains(actionURL))
                                    {
                                        filterContext.Result = null;
                                    }
                                    if (filterContext.Result == null)
                                    {
                                        if (UserPermissionArray.Contains("add"))
                                        {
                                            ViewBag.AllowAdding = true;
                                        }
                                        if (UserPermissionArray.Contains("edit"))
                                        {
                                            ViewBag.AllowEditing = true;
                                        }
                                        if (UserPermissionArray.Contains("delete"))
                                        {
                                            ViewBag.AllowDeleting = true;
                                        }
                                        if (UserPermissionArray.Contains("view"))
                                        {
                                            ViewBag.AllowViewing = true;
                                        }
                                        if (UserPermissionArray.Contains("sorting"))
                                        {
                                            ViewBag.AllowSorting = true;
                                        }
                                    }
                                }
                                if (filterContext.Result == null)
                                {
                                    ViewBag.ControllerName = UserRolePermissionRecord.Menu.Title;
                                }
                            }
                        }
                    }

                    if (filterContext.Result == null)
                    {
                        if (UserRolePermissionRecords.Count > 0)
                        {
                            ViewBag.UserRolePermissionRecords = UserRolePermissionRecords;

                            var userRoleParentPermission = dbContext.BackendMenus.Where(x => x.ParentId == null).ToList();
                            ViewBag.UserRoleParentPermissionRecords = userRoleParentPermission;
                        }
                        List<BreadCrumbMenu> breadCrumbList = new List<BreadCrumbMenu>();
                        if (!string.IsNullOrWhiteSpace(actionURL))
                        {
                            ViewBag.ActionName = UpperCaseFirstLetter(actionURL);
                            ViewBag.ActionURL = controllerURL;
                            if (!controllerURL.Equals("dashboard"))
                            {
                                breadCrumbList.Add(new BreadCrumbMenu { Name = ViewBag.ControllerName, AccessURL = ConvertToWebURL(dbContext, "admin/" + controllerURL), ClassName = "" });
                            }
                            breadCrumbList.Add(new BreadCrumbMenu { Name = ViewBag.ActionName, AccessURL = "#", ClassName = "active" });
                        }
                        else
                        {
                            breadCrumbList.Add(new BreadCrumbMenu { Name = ViewBag.ControllerName, AccessURL = "#", ClassName = "active" });
                        }
                        ViewBag.BreadCrumbMenus = breadCrumbList;
                        ViewBag.PageURL = ViewBag.WebsiteURL + controllerURL;
                        ViewBag.PageName = controllerURL;
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }



    }
}
