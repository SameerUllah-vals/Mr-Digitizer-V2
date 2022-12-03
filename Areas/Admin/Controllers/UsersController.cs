
using MrDigitizerV2.Helpers;
using MrDigitizerV2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using static MrDigitizerV2.Helpers.ApplicationHelper;

namespace MrDigitizerV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/users")]
    public class UsersController : BaseController
    {
        IWebHostEnvironment webHostEnvironment;
        public UsersController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public ActionResult Index()
        {
            ViewBag.PageType = EnumPageType.Index;
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
                var Data = (from x in dbContext.Users.Where(x => x.Id != EnumRole.SuperAdmin && !x.IsDeleted) select x);
                if (!string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection))
                {
                    Data = Data.Where(x => !x.IsDeleted).OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    Data = Data.Where(m => m.Fullname.Contains(searchValue)
                                                || m.Role.Title.Contains(searchValue)
                                                || m.EmailAddress.Contains(searchValue)
                                                || m.PhoneNumber.Contains(searchValue)
                                                || m.Status.Contains(searchValue)
                                                || m.CreatedDateTime.ToString().Contains(searchValue)
                                                || m.UpdatedDateTime.ToString().Contains(searchValue));
                }
                recordsTotal = Data.Count();
                var resultList = Data.Skip(skip).Take(pageSize).ToList();
                var resultData = from x in resultList.Where(x => !x.IsDeleted)
                                 select new
                                 {
                                     x.Id,
                                     Role = x.Role.Title,
                                     x.Fullname,
                                     x.EmailAddress,
                                     x.PhoneNumber,
                                     x.Status,
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

        [Route("add")]
        public IActionResult Add()
        {
            ViewBag.PageType = EnumPageType.Add;
            FillDropDown();
            return View("Form", new Users());
        }

        [Route("GetRecord")]
        public Users GetRecord(Guid? id)
        {
            var record = dbContext.Users.FirstOrDefault(o => o.Id == id && o.IsDeleted == false);
            if (record != null)
            {
                record.Password = Decrypt(record.Password);
                record.ConfirmPassword = record.Password;
                FillDropDown();
            }
            return record;

        }

        [Route("view")]
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
                return Redirect(ViewBag.WebsiteURL + "users/add");
            }
        }

        [Route("edit")]
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
                return Redirect(ViewBag.WebsiteURL + "users/add");
            }
        }

        [Route("save")]
        [HttpPut]
        [HttpPost]
        public JsonResult Save(Users modelRecord)
        {
            AjaxResponse ajaxResponse = new AjaxResponse();
            ajaxResponse.Success = false;
            ajaxResponse.Type = EnumJQueryResponseType.MessageOnly;
            ajaxResponse.Message = "Post Data Not Found";
            try
            {
                if (IsAdminLogin(this))
                {
                    bool isAbleToAddOrUpdate = true;

                    if (isAbleToAddOrUpdate)
                    {
                        bool isRecordWillAdded = false;
                        modelRecord.Password = Encrypt(modelRecord.Password);
                        if (modelRecord.Id == Guid.Empty)
                        {

                            if (modelRecord.File != null)
                                modelRecord.ProfileImagePath = UploadFileToFolder(modelRecord.File, Path.Combine(webHostEnvironment.WebRootPath, EnumFileUploadFolder.ProfileImage));
                            isRecordWillAdded = true;
                            modelRecord.Id = Guid.NewGuid();
                            modelRecord.IsDeleted = false;
                            modelRecord.CreatedDateTime = GetDateTime(dbContext);
                            modelRecord.UtccreatedDateTime = GetUtcDateTime();
                            modelRecord.CreatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                            dbContext.Users.Add(modelRecord);

                        }
                        else
                        {
                            if (modelRecord.File != null)
                                modelRecord.ProfileImagePath = UploadFileToFolder(modelRecord.File, Path.Combine(webHostEnvironment.WebRootPath, EnumFileUploadFolder.ProfileImage));
                            modelRecord.IsDeleted = false;
                            modelRecord.UpdatedDateTime = GetDateTime(dbContext);
                            modelRecord.UtcupdatedDateTime = GetUtcDateTime();
                            modelRecord.UpdatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); 
                            dbContext.Users.Update(modelRecord);
                        }
                        dbContext.SaveChanges();
                        ajaxResponse.Type = EnumJQueryResponseType.MessageAndRedirectWithDelay;
                        ajaxResponse.TargetURL = ViewBag.WebsiteURL + "users";
                        if (isRecordWillAdded)
                        {
                            ajaxResponse.Message = "Record Added Successfully";
                        }
                        else
                        {
                            ajaxResponse.Message = "Record Updated Successfully";
                        }
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
        [Route("delete")]
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
                        var RecordToDelete = dbContext.Users.FirstOrDefault(o => o.Id == _value);
                        if (RecordToDelete != null)
                        {
                            RecordToDelete.IsDeleted = true;
                            RecordToDelete.DeletedBy = currentUserId;
                            RecordToDelete.UtcdeletedDateTime = GetUtcDateTime();
                            RecordToDelete.DeletedDateTime = GetDateTime();
                            dbContext.Users.Update(RecordToDelete);
                            dbContext.SaveChanges();
                            ajaxResponse.Success = true;
                            ajaxResponse.Message = "Record Deleted Successfully";

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


        [Route("FillDropDown")]
        public void FillDropDown()
        {
            ViewBag.Roles = dbContext.Roles.Where(x => x.IsDeleted.Equals(false)).ToList();
        }
    }
}
