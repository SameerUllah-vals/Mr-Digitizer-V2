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
    [Route("admin/cities")]
    public class CitiesController : BaseController
    {
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
                var Data = (from x in dbContext.Cities.Where(x => x.Id != EnumRole.SuperAdmin && !x.IsDeleted) select x);
                if (!string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection))
                {
                    Data = Data.Where(x => !x.IsDeleted).OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    Data = Data.Where(m => m.Title.Contains(searchValue)
                                                || m.State.Title.Contains(searchValue)
                                                || m.Country.Title.Contains(searchValue)
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
                                     Country = x.Country.Title,
                                     State = x.State.Title,
                                     x.Title,
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
        [Route("GetRecord")]
        public Cities GetRecord(Guid? id)
        {
            var Record = dbContext.Cities.FirstOrDefault(o => o.Id == id && o.IsDeleted == false);
            ViewBag.Country = dbContext.Countries.Where(x => !x.IsDeleted).OrderBy(x => x.Title).Select(x => new Countries { Id = x.Id, Title = x.Title }).ToList();
            return Record;
        }
        [Route("Add")]
        public IActionResult Add()
        {
            ViewBag.Country = dbContext.Countries.Where(x => !x.IsDeleted).OrderBy(x => x.Title).Select(x => new Countries{ Id = x.Id, Title = x.Title }).ToList();
            return View("Form", new Cities());
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
                return Redirect(ViewBag.WebsiteURL + "cities/add");
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
                return Redirect(ViewBag.WebsiteURL + "cities/add");
            }
        }
        [Route("Save")]
        public JsonResult Save(Cities modelRecord)
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
                    Cities Record = dbContext.Cities.FirstOrDefault(o => o.Id != modelRecord.Id && o.Title.ToLower().Equals(modelRecord.Title.ToLower()) && o.IsDeleted == false);
                    if (Record != null && modelRecord.Id == Guid.Empty)
                    {
                        ajaxResponse.Message = "Title already exist in our records";
                        isAbleToAddOrUpdate = false;
                    }
                    if (isAbleToAddOrUpdate)
                    {
                        bool isRecordWillAdded = false;
                        if (modelRecord.Id == Guid.Empty)
                        {
                            isRecordWillAdded = true;
                            modelRecord.Id =  Guid.NewGuid();
                            modelRecord.CreatedDateTime = GetDateTime(dbContext);
                            modelRecord.UtccreatedDateTime = GetUtcDateTime();
                            modelRecord.CreatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                            dbContext.Cities.Add(modelRecord);
                        }
                        else
                        {

                            modelRecord.UpdatedDateTime = GetDateTime(dbContext);
                            modelRecord.UtcupdatedDateTime = GetUtcDateTime();
                            modelRecord.UpdatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); ;
                            dbContext.Cities.Update(modelRecord);
                        }
                        dbContext.SaveChanges();
                        if (isRecordWillAdded)
                        {
                            ajaxResponse.Message = "City Added Successfully";
                        }
                        else
                        {
                           ajaxResponse.Message = "City Updated Successfully";                            
                        }
                        ajaxResponse.Type = EnumJQueryResponseType.MessageAndRedirectWithDelay;
                        ajaxResponse.TargetURL = ViewBag.WebsiteURL + "cities";
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
                        var RecordToDelete = dbContext.Cities.FirstOrDefault(o => o.Id == _value);
                        if (RecordToDelete != null)
                        {
                            RecordToDelete.IsDeleted = true;
                            RecordToDelete.DeletedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                            RecordToDelete.UtcdeletedDateTime = GetUtcDateTime();
                            RecordToDelete.DeletedDateTime = GetDateTime(dbContext);
                            dbContext.Cities.Update(RecordToDelete);
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
        [HttpGet]
        [Route("GetStates")]
        public JsonResult GetStates(Guid? Id)
        {
            return Json(dbContext.States.Where(x => x.CountryId == Id && x.Status.Equals(EnumStatus.Enable) && !x.IsDeleted).Select(x => new { x.Id, x.Title }).ToList());
        }
    }
}
