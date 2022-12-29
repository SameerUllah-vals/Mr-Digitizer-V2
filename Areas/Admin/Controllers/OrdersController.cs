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
using System.Net.Mail;

namespace MrDigitizerV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/orders")]
    public class OrdersController : BaseController
    {
        IWebHostEnvironment webHostEnvironment;
        public OrdersController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Listener")]
        public IActionResult Listener(string status)
        {
            try
            {
                string RoleName = User.FindFirstValue("RoleName").ToLower();
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
                if(RoleName == EnumRoleTypes.Admin)
                {                   
                    Data = (from x in dbContext.Orders.Where(x => !x.IsDeleted) select x);
                }
                else if(RoleName == EnumRoleTypes.Designer)
                {
                    Data = (from x in dbContext.Orders.Where(x => x.DeisgnerId == Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) && !x.IsDeleted) select x);
                }
                else
                {
                    Data = (from x in dbContext.Orders.Where(x => x.CreatedBy == Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) && !x.IsDeleted) select x);
                }
                if (!string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection))
                {
                    Data = Data.Where(x => !x.IsDeleted).OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(status))
                {
                    Data = Data.Where(x => x.OrderStatus.OrderByDescending(x => x.DateTime).FirstOrDefault().Status.Contains(status));
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    Data = Data.Where(m => m.DesignName.Contains(searchValue)
                                                || m.User.EmailAddress.Contains(searchValue)
                                                || m.User.PhoneNumber.Contains(searchValue)
                                                || m.User.Fullname.Contains(searchValue)
                                                || m.OrderStatus.OrderByDescending(x => x.DateTime).FirstOrDefault().Status.Contains(searchValue)
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
                                     Status = x.OrderStatus.OrderByDescending(x => x.DateTime).FirstOrDefault().Status,
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



        [HttpPost]
        [Route("ListenerChild")]
        public IActionResult ListenerChild(Guid OrderId)
        {
            try
            {
                string RoleName = User.FindFirstValue("RoleName").ToLower();
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                IQueryable<OrderDocuments> Data;
                if (RoleName == EnumRoleTypes.Admin)
                {
                    Data = (from x in dbContext.OrderDocuments.Where(x => x.OrderId == OrderId).OrderByDescending(x => x.CreatedDateTime) select x);
                }
                else if (RoleName == EnumRoleTypes.Designer)
                {
                    Data = (from x in dbContext.OrderDocuments.Where(x => x.OrderId == OrderId && x.User.Role.Title.ToLower() != EnumRoleTypes.Member).OrderByDescending(x => x.CreatedDateTime) select x);
                }
                else
                {
                    Data = (from x in dbContext.OrderDocuments.Where(x => x.OrderId == OrderId && x.User.Role.Title.ToLower() == EnumRoleTypes.Member).OrderByDescending(x => x.CreatedDateTime) select x);
                }
                if (!string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection))
                {
                    Data = Data.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    Data = Data.Where(m => m.FilePath.Contains(searchValue)
                                                || m.Extension.Contains(searchValue)
                                                || m.User.Role.Title.Contains(searchValue));
                }
                recordsTotal = Data.Count();
                var resultList = Data.Skip(skip).Take(pageSize).ToList();
                var resultData = from x in resultList
                                 select new
                                 {
                                     x.Id,
                                     FileName = x.FileName,
                                     FilePath = x.FilePath,
                                     Extension = x.Extension,
                                     UploadedBy = string.Format("{0} ({1})", x.User.Fullname, x.User.Role.Title),
                                     CreatedDateTime = x.CreatedDateTime,
                                     CreatedDateTimeString = x.CreatedDateTime.ToString(Website_Date_Time_Format),
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
            FillDropDown();
            return Record;
        }
        [Route("Add")]
        public IActionResult Add()
        {
            FillDropDown();
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
                    string RoleName = User.FindFirstValue("RoleName").ToLower();
                    bool isAbleToAddOrUpdate = true;
                    bool isCompletedOrder = dbContext.OrderStatus.Any(x => x.OrderId == modelRecord.Id && x.Status == EnumStatus.Completed);
                    if (isCompletedOrder)
                    {
                        ajaxResponse.Message = "You cannot edit this order because it has been closed.";
                        isAbleToAddOrUpdate = false;
                    }
                    else if (modelRecord.Id != Guid.Empty)
                    {                       
                        if (RoleName == EnumRoleTypes.Member)
                        {
                            bool isAssignedOrder = dbContext.OrderStatus.Any(x => x.OrderId == modelRecord.Id && x.Status == EnumStatus.Assigned);
                            if (isAssignedOrder)
                            {
                                string emailAddress = dbContext.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Sender_Key)).Content;
                                ajaxResponse.Message = "You cannot edit this order because it has been assigned. for more information email us on orders@anonymousdigitizing.com";
                                isAbleToAddOrUpdate = false;
                            }
                        }                       
                    }                   
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
                            OrderStatus orderStatus = new OrderStatus
                            {
                                Id = Guid.NewGuid(),
                                OrderId = modelRecord.Id,
                                Status = EnumStatus.Unassigned,
                                DateTime = GetDateTime()
                            };
                            dbContext.OrderStatus.Add(orderStatus);
                        }
                        else
                        {
                            modelRecord.UpdatedDateTime = GetDateTime(dbContext);
                            modelRecord.UpdatedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));                          
                            if (RoleName == EnumRoleTypes.Admin)
                            {
                                dbContext.Orders.Update(modelRecord);
                                if (modelRecord.DeisgnerId != Guid.Empty)
                                {
                                    bool isAssignedOrder = dbContext.OrderStatus.Any(x => x.OrderId == modelRecord.Id && x.Status == EnumStatus.Assigned);
                                    if (!isAssignedOrder)
                                    {
                                        OrderStatus orderStatus = new OrderStatus
                                        {
                                            Id = Guid.NewGuid(),
                                            OrderId = modelRecord.Id,
                                            Status = EnumStatus.Assigned,
                                            DateTime = GetDateTime()
                                        };
                                        dbContext.OrderStatus.Add(orderStatus);
                                    }
                                }
                              
                            }
                            else if(RoleName == EnumRoleTypes.Member)
                            {
                                dbContext.Orders.Update(modelRecord);
                            }
                            else if(RoleName == EnumRoleTypes.Designer)
                            {                               
                                OrderStatus orderStatus = new OrderStatus
                                {
                                    Id = Guid.NewGuid(),
                                    OrderId = modelRecord.Id,
                                    Status = EnumStatus.Completed,
                                    DateTime = GetDateTime()
                                };
                                dbContext.OrderStatus.Add(orderStatus);                                
                            }                            
                        }
                        if(modelRecord.Files.Count > 0)
                        {
                            var oldFiles = dbContext.OrderDocuments.Where(x => x.OrderId == modelRecord.Id && x.User.Role.Title.ToLower() == RoleName).ToList();
                            if (oldFiles.Count > 0)
                            {
                                dbContext.OrderDocuments.RemoveRange(oldFiles);
                            }
                            foreach (var file in modelRecord.Files)
                            {
                                OrderDocuments fileRecord = new OrderDocuments
                                {
                                    Id = Guid.NewGuid(),
                                    OrderId = modelRecord.Id,
                                    UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                                    FileName = file.FileName,
                                    Extension = Path.GetExtension(file.FileName),
                                    CreatedDateTime = GetDateTime()
                                };
                                fileRecord.FilePath = UploadFileToFolder(file, Path.Combine(webHostEnvironment.WebRootPath, EnumFileUploadFolder.Documents));
                                dbContext.OrderDocuments.Add(fileRecord);
                            }
                        }
                       
                        dbContext.SaveChanges();
                        if (isRecordWillAdded)
                        {
                            ajaxResponse.Message = "Order submitted successfully";
                        }
                        else
                        {
                            ajaxResponse.Message = "Order updated successfully";
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
                            bool isAbleToCancel = RecordToDelete.OrderStatus.Any(x => x.Status == EnumStatus.Assigned);
                            if (User.FindFirstValue("RoleName").ToLower() == EnumRoleTypes.Admin)
                            {
                                isAbleToCancel = false;
                            }                           
                            if (!isAbleToCancel)
                            {
                                OrderStatus record = new OrderStatus()
                                {
                                    Id = Guid.NewGuid(),
                                    DateTime = GetDateTime(),
                                    OrderId = RecordToDelete.Id,
                                    Status = EnumStatus.Cancelled
                                };
                                dbContext.OrderStatus.Add(record);
                                dbContext.SaveChanges();
                                ajaxResponse.Success = true;
                                ajaxResponse.Message = "Order successfully cancelled";
                            }
                            else
                            {
                                ajaxResponse.Message = "You cannot cancel this order because it has been assigned. for any query email us on orders@anonymousdigitizing.com";
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

        [Route("FillDropDown")]
        public void FillDropDown()
        {
            ViewBag.Designers = dbContext.Users.Where(x => x.Role.Title.ToLower() == EnumRoleTypes.Designer && x.Status.Equals(EnumStatus.Enable) && !x.IsDeleted)
                .Select(s => new Users { Id = s.Id, Fullname = s.Fullname}).ToList();
        }
    }
}
