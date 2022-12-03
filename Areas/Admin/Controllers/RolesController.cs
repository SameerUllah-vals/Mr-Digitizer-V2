
using MrDigitizerV2.Helpers;
using MrDigitizerV2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static MrDigitizerV2.Helpers.ApplicationHelper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MrDigitizerV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/roles")]
    public class RolesController : BaseController
    {
   
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("Listener")]
        public IActionResult Listener()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var Data = (from x in dbContext.Roles.Where(x => x.Id != EnumRole.SuperAdmin && !x.IsDeleted) select x);
                if (!string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection))
                {
                    Data = Data.Where(x => !x.IsDeleted).OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    Data = Data.Where(m => m.Title.Contains(searchValue)
                                                || m.CreatedDateTime.ToString().Contains(searchValue)
                                                || m.UpdatedDateTime.ToString().Contains(searchValue));
                }
                recordsTotal = Data.Count();
                var resultList = Data.Skip(skip).Take(pageSize).ToList();
                var resultData = from x in resultList.Where(x => !x.IsDeleted)
                                 select new
                                 {
                                     x.Id,
                                     x.Title,
                                     CreatedDateTime = x.CreatedDateTime,
                                     CreatedDateTimeString = x.CreatedDateTime.ToString(Website_Date_Time_Format),
                                     UpdatedDateTime = !x.UpdatedDateTime.HasValue ? "" : x.UpdatedDateTime.Value.ToString(Website_Date_Time_Format)
                                 };

                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = resultData };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("Add")]

        public IActionResult Add()
        {
            ViewBag.PageType = EnumPageType.Add;
            return View("Form", new Roles());
        }

        [Route("GetRecord")]

        public Roles GetRecord(Guid? id)
        {
            var Record = dbContext.Roles.FirstOrDefault(o => o.Id != EnumRole.SuperAdmin && o.Id == id && o.IsDeleted == false);
            if (Record != null)
            {
                var RolePermissionRecords = Record.RoleBackendMenus.OrderBy(o => o.Position).ToList();
                if (RolePermissionRecords.Count > 0)
                {
                    string rolePermission = string.Empty;
                    foreach (RoleBackendMenus RP in RolePermissionRecords)
                    {
                        rolePermission += RP.MenuId + "," + RP.Permission + "||";
                    }
                    if (!string.IsNullOrWhiteSpace(rolePermission))
                    {
                        rolePermission = rolePermission.Remove(rolePermission.Length - 2, 2);
                        ViewBag.RolePermission = rolePermission;
                    }
                }
            }
            return Record;
        }

       [Route("View")]
        public IActionResult View(Guid? id)
        {
            var Record = GetRecord(id);
            if (Record != null)
            {
                ViewBag.PageType = EnumPageType.View;
                return View("Form", Record);
            }
            else
            {
                return Redirect(ViewBag.WebsiteURL + "roles/add");
            }
        }

        [Route("Edit")]
        public IActionResult Edit(Guid? id)
        {
            var Record = GetRecord(id);
            if (Record != null)
            {

                ViewBag.PageType = EnumPageType.Edit;
                return View("Form", Record);
            }
            else
            {
                return Redirect(ViewBag.WebsiteURL + "roles/add");
            }
        }


        [Route("Save")]
        public JsonResult Save(Roles modelRecord, string RolePermission)
        {
            AjaxResponse ajaxResponse = new AjaxResponse();
            ajaxResponse.Success = false;
            ajaxResponse.Type = EnumJQueryResponseType.MessageOnly;
            ajaxResponse.Message = "Post Data Not Found";
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    bool isAbleToAddOrUpdate = true;
                    bool isRecordEditable = true;
                    Roles Record = dbContext.Roles.FirstOrDefault(o => o.Id != modelRecord.Id && o.Title.ToLower().Equals(modelRecord.Title.ToLower()) && o.IsDeleted == false);
                    if (Record != null && modelRecord.Id == Guid.Empty)
                    {
                        ajaxResponse.Message = "Name already exist in our records";
                        isAbleToAddOrUpdate = false;
                    }
                    if (isAbleToAddOrUpdate)
                    {
                        bool isRecordWillAdded = false;
                        if (modelRecord.Id == Guid.Empty)
                        {
                            isRecordWillAdded = true;
                            modelRecord.CreatedDateTime = GetDateTime(dbContext);
                            modelRecord.UtccreatedDateTime = GetUtcDateTime();
                            modelRecord.CreatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                            dbContext.Roles.Add(modelRecord);
                        }
                        else
                        {

                            modelRecord.UpdatedDateTime = GetDateTime(dbContext);
                            modelRecord.UtcupdatedDateTime = GetUtcDateTime();
                            modelRecord.UpdatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); ;
                            dbContext.Roles.Update(modelRecord);
                        }
                        dbContext.SaveChanges();
                        if (!string.IsNullOrWhiteSpace(RolePermission))
                        {
                            List<Guid> MenuIds = new List<Guid>();
                            string[] RecordRolePermissionArray = RolePermission.Split(new string[] { "||" }, StringSplitOptions.None);
                            if (RecordRolePermissionArray.Length > 0)
                            {
                                int SequenceOrder = 0;
                                foreach (string RolePermission1 in RecordRolePermissionArray)
                                {
                                    string[] RolePermissionArray = RolePermission1.Split(',');
                                    if (RolePermissionArray.Length == 2)
                                    {
                                        Guid MenuID = Guid.Parse(RolePermissionArray[0]);
                                        string MenuPermission = ParseString(RolePermissionArray[1]);
                                        if (MenuID != Guid.Empty && !string.IsNullOrWhiteSpace(MenuPermission))
                                        {
                                            if (MenuPermission.Equals("None"))
                                            {
                                                var RecordToDelete = dbContext.RoleBackendMenus.FirstOrDefault(o => o.MenuId == MenuID && o.RoleId == modelRecord.Id);
                                                if (RecordToDelete != null)
                                                {
                                                    dbContext.RoleBackendMenus.Remove(RecordToDelete);
                                                    dbContext.SaveChanges();
                                                }
                                            }
                                            else
                                            {
                                                bool isPermissionAdd = false;
                                                var RolePermissionRecord = dbContext.RoleBackendMenus.FirstOrDefault(o => o.MenuId == MenuID && o.RoleId == modelRecord.Id);
                                                if (RolePermissionRecord == null)
                                                {
                                                    isPermissionAdd = true;
                                                    RolePermissionRecord = new RoleBackendMenus();
                                                }
                                                MenuIds.Add(MenuID);
                                                RolePermissionRecord.RoleId = modelRecord.Id;
                                                RolePermissionRecord.MenuId = MenuID;
                                                RolePermissionRecord.Permission = MenuPermission;
                                                //RolePermissionRecord.Type = EnumMenuType.Children;
                                                if (isPermissionAdd)
                                                {
                                                    RolePermissionRecord.Position = SequenceOrder;
                                                    dbContext.RoleBackendMenus.Add(RolePermissionRecord);
                                                    SequenceOrder += 1;
                                                }
                                                else
                                                {
                                                    dbContext.RoleBackendMenus.Update(RolePermissionRecord);
                                                }
                                                dbContext.SaveChanges();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (isRecordWillAdded)
                        {
                            ajaxResponse.Message = "Role Added Successfully";
                        }
                        else
                        {
                            if (!isRecordEditable)
                            {
                                ajaxResponse.Message = "Role Updated Successfully But Name Of This Record Cannot Be Modified";
                            }
                            else
                            {
                                ajaxResponse.Message = "Role Updated Successfully";
                            }
                        }
                        ajaxResponse.Type = EnumJQueryResponseType.MessageAndRedirectWithDelay;
                        ajaxResponse.TargetURL = ViewBag.WebsiteURL + "roles";
                        ajaxResponse.Success = true;
                    }
                }
                else
                {
                    ajaxResponse.Type = EnumJQueryResponseType.MessageAndRedirectWithDelay;
                    ajaxResponse.Message = "Session Expired";
                    ajaxResponse.TargetURL = ViewBag.WebsiteURL;
                }
            }
            catch (Exception ex)
            {
                string _catchMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    _catchMessage += "<br/>" + ex.InnerException.Message;
                }
                ajaxResponse.Message = _catchMessage;
            }
            return Json(ajaxResponse);
        }


        [HttpPost]
        [Route("Delete")]
        public JsonResult Delete(Guid? _value)
        {
            AjaxResponse ajaxResponse = new AjaxResponse();
            ajaxResponse.Success = false;
            ajaxResponse.Type = EnumJQueryResponseType.MessageOnly;
            ajaxResponse.Message = "Data not found in our records";
            try
            {
                if (IsAdminLogin(this))
                {
                    if (_value == Guid.Empty || _value == null)
                    {
                        ajaxResponse.Message = "Id is not in correct format";
                    }
                    else
                    {
                        var RecordToDelete = dbContext.Roles.FirstOrDefault(o => o.Id == _value);
                        if (RecordToDelete != null)
                        {
                            if (RecordToDelete.Users.Where(x => !x.IsDeleted).Count() > 0)
                            {
                                ajaxResponse.Message = "Unable to delete this record because of some reference data";
                            }
                            else
                            {

                                RecordToDelete.IsDeleted = true;
                                RecordToDelete.DeletedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                                RecordToDelete.UtcdeletedDateTime = GetUtcDateTime();
                                RecordToDelete.DeletedDateTime = GetDateTime(dbContext);
                                dbContext.Roles.Update(RecordToDelete);
                                dbContext.SaveChanges();
                                ajaxResponse.Success = true;
                                ajaxResponse.Message = "Record Deleted Successfully";
                            }
                        }
                    }
                }
                else
                {
                    ajaxResponse.Type = EnumJQueryResponseType.RedirectWithDelay;
                    ajaxResponse.Message = "Session Expired";
                    ajaxResponse.TargetURL = ViewBag.WebsiteURL;
                }
            }
            catch (Exception ex)
            {
                string _catchMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    _catchMessage += "<br/>" + ex.InnerException.Message;
                }
                ajaxResponse.Message = _catchMessage;
            }
            return Json(ajaxResponse);
        }


        [HttpPost]
        [Route("GetMenuRecords")]
        public JsonResult GetMenuRecords(Guid id)
        {
            AjaxResponse ajaxResponse = new AjaxResponse();
            ajaxResponse.Success = false;
            ajaxResponse.Type = EnumJQueryResponseType.MessageOnly;
            ajaxResponse.Message = "No Record Found";
            
            var roleRecord = dbContext.Users.FirstOrDefault(x => x.Fullname.Equals("Super Admin")).Role;
            List<BackendMenus> SubscriptionMenuRecords;
            SubscriptionMenuRecords = dbContext.RoleBackendMenus.Where(x => x.RoleId == roleRecord.Id && x.Menu.Type == "SuperAdmin").Select(x => x.Menu).ToList();
            IEnumerable<BackendMenus> menuRecords;
            menuRecords = SubscriptionMenuRecords.Distinct().ToList();
            if (menuRecords.Count() > 0)
            {
                List<Guid> DuplicateRecord = new List<Guid>();
                List<object> menuList = new List<object>();
                IEnumerable<BackendMenus> childMenuRecords;
                foreach (var parentMenu in menuRecords.ToList())
                {
                    if (!DuplicateRecord.Contains(parentMenu.ParentId == null ? Guid.NewGuid() : parentMenu.ParentId.ToGuid()))
                    {
                        DuplicateRecord.Add(parentMenu.ParentId == null ? Guid.NewGuid() : parentMenu.ParentId.ToGuid());
                        Dictionary<string, object> menuDictionary = new Dictionary<string, object>();
                        if (parentMenu.Parent != null)
                        {
                            if(SubscriptionMenuRecords.Where(o => o.ParentId == parentMenu.ParentId).Count() != 0)
                            {
                                menuDictionary.Add("ID", parentMenu.Parent.Id);
                                menuDictionary.Add("Name", parentMenu.Parent.Title);
                                childMenuRecords = SubscriptionMenuRecords.Where(o => o.ParentId == parentMenu.ParentId);
                            }
                            else
                            {
                                childMenuRecords = new List<BackendMenus>();
                            }
                          
                        }
                        else
                        {
                            if (SubscriptionMenuRecords.Where(o => o.ParentId == parentMenu.ParentId).Count() != 0)
                            {
                                menuDictionary.Add("ID", parentMenu.Id);
                                menuDictionary.Add("Name", parentMenu.Title);
                                childMenuRecords = SubscriptionMenuRecords.Where(o => o.Id == parentMenu.Id);
                            }
                            else
                            {
                               childMenuRecords = new List<BackendMenus>();
                            }
                        }

                        if (childMenuRecords.Count() > 0)
                        {
                            List<object> childMenuList = new List<object>();
                            foreach (var childMenu in childMenuRecords)
                            {
                                Dictionary<string, object> childMenuDictionary = new Dictionary<string, object>();
                                childMenuDictionary.Add("ID", childMenu.Id);
                                childMenuDictionary.Add("Name", childMenu.Title);
                                //  List<MenuPermissions> menuPermissionRecords;
                                var menuPermissionRecords = childMenu.BackendMenuDetails.OrderBy(o => o.SequenceOrder).ToList();
                                List<object> childMenuPermissionList = new List<object>();
                                foreach (var _MenuPermission in menuPermissionRecords)
                                {
                                    Dictionary<string, object> menuPermissionDictionary = new Dictionary<string, object>();
                                    menuPermissionDictionary.Add("ID", _MenuPermission.Id);
                                    menuPermissionDictionary.Add("Name", _MenuPermission.Name);
                                    menuPermissionDictionary.Add("Type", _MenuPermission.Type);
                                    bool isSelected = false;
                                    var rolePermissionRecord = dbContext.RoleBackendMenus.FirstOrDefault(o => o.RoleId == id && o.MenuId == childMenu.Id);
                                    if (rolePermissionRecord != null)
                                    {
                                        string[] assignPermission = rolePermissionRecord.Permission.Split('|');
                                        if (assignPermission.Contains(_MenuPermission.Name))
                                        {
                                            isSelected = true;
                                        }
                                    }
                                    menuPermissionDictionary.Add("Selected", isSelected);
                                    childMenuPermissionList.Add(menuPermissionDictionary);
                                }
                                childMenuDictionary.Add("Permissions", childMenuPermissionList);
                                childMenuList.Add(childMenuDictionary);
                            }
                            menuDictionary.Add("Menus", childMenuList);
                            menuList.Add(menuDictionary);
                        }
                    }
                }
                ajaxResponse.Success = true;
                ajaxResponse.Message = null;
                ajaxResponse.Type = EnumJQueryResponseType.DataOnly;
                ajaxResponse.Data = JsonConvert.SerializeObject(menuList);
            }
            return Json(ajaxResponse);
        }
    }
}
