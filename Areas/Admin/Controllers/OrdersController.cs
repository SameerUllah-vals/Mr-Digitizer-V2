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
    [Route("admin/orders")]
    public class OrdersController : BaseController
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
                IQueryable<Orders> Data;
                if(Guid.Parse(User.FindFirstValue(ClaimTypes.Role)) != EnumRole.SuperAdmin)
                {
                    Data = (from x in dbContext.Orders.Where(x => x.Id == Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) && !x.IsDeleted) select x);
                }
                else
                {
                    Data = (from x in dbContext.Orders.Where(x => !x.IsDeleted) select x);
                }
                if (!string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection))
                {
                    Data = Data.Where(x => !x.IsDeleted).OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    Data = Data.Where(m => m.DesignName.Contains(searchValue)
                                                || m.User.EmailAddress.Contains(searchValue)
                                                || m.User.PhoneNumber.Contains(searchValue)
                                                || m.User.Fullname.Contains(searchValue)
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
                                     OrderType = x.OrderType,
                                     CustomerName = x.User.Fullname,
                                     x.DesignName,
                                     EmailAddress = x.User.EmailAddress,
                                     PhoneNumber = x.User.PhoneNumber,
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
        public Orders GetRecord(Guid? id)
        {
            var Record = dbContext.Orders.FirstOrDefault(o => o.Id == id && o.IsDeleted == false);
            return Record;
        }
        [Route("Add")]
        public IActionResult Add()
        {
            ViewBag.PageType = EnumPageType.Add;
            return View("Form", new Orders());
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
                return Redirect(ViewBag.WebsiteURL + "orders/add");
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
                return Redirect(ViewBag.WebsiteURL + "orders/add");
            }
        }
        [Route("Save")]
        public JsonResult Save(Orders modelRecord)
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
                    if (isAbleToAddOrUpdate)
                    {
                        bool isRecordWillAdded = false;
                        if (modelRecord.Id == Guid.Empty)
                        {
                            isRecordWillAdded = true;
                            modelRecord.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                            modelRecord.Id = Guid.NewGuid();
                            modelRecord.CreatedDateTime = GetDateTime(dbContext);
                            modelRecord.CreatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                            dbContext.Orders.Add(modelRecord);
                        }
                        else
                        {

                            modelRecord.UpdatedDateTime = GetDateTime(dbContext);
                            modelRecord.UpdatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); ;
                            dbContext.Orders.Update(modelRecord);
                        }
                        dbContext.SaveChanges();
                        if (isRecordWillAdded)
                        {
                            ajaxResponse.Message = "Your order submitted successfully";
                        }
                        else
                        {
                            ajaxResponse.Message = "order updated successfully";
                        }
                        ajaxResponse.Type = EnumJQueryResponseType.MessageAndRedirectWithDelay;
                        ajaxResponse.TargetURL = ViewBag.WebsiteURL + "orders";
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
                        var RecordToDelete = dbContext.Orders.FirstOrDefault(o => o.Id == _value);
                        if (RecordToDelete != null)
                        {
                            RecordToDelete.IsDeleted = true;
                            dbContext.Orders.Update(RecordToDelete);
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
    }
}
