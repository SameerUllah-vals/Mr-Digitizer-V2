using Microsoft.AspNetCore.Mvc;
using MrDigitizerV2.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using static MrDigitizerV2.Helpers.ApplicationHelper;

namespace MrDigitizerV2.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("admin/email")]
    public class EmailController : BaseController
    {       
        public IActionResult Index(Guid OrderId)
        {
            EmailMeta meta = new EmailMeta();
            var Record = dbContext.Orders.FirstOrDefault(x => x.Id == OrderId);
            if (Record != null)
            {
                meta.Id = Record.Id;
                meta.OrderType = Record.OrderType;
                meta.DesignName = Record.DesignName;
                meta.EmailAddress = Record.User.EmailAddress;
                meta.Fullname = Record.User.Fullname;
                meta.OrderDocuments = Record.OrderDocuments.Where(x => x.User.Role.Title.ToLower() == EnumRoleTypes.Designer).ToList();
                meta.WebsiteURL = ViewBag.WebsiteURL;
                meta.WebsiteURL = meta.WebsiteURL.Replace("admin/", "");
            }
            else
            {
                return Redirect(ViewBag.WebsiteURL + "orders");
            }
            return View(meta);
        }

        [HttpPost]
        [Route("sendemail")]
        public async Task<IActionResult> SendEmailAsync(EmailMeta modelRecord)
        {
            AjaxResponse ajaxResponse = new AjaxResponse();
            ajaxResponse.Success = false;
            ajaxResponse.Type = EnumJQueryResponseType.MessageOnly;
            ajaxResponse.Message = "Post Data Not Found";
            try
            {
                var Record = dbContext.Orders.FirstOrDefault(x => x.Id == modelRecord.Id);
                if (Record != null)
                {
                    modelRecord.Id = Record.Id;
                    modelRecord.OrderType = Record.OrderType;
                    modelRecord.DesignName = Record.DesignName;
                    modelRecord.EmailAddress = Record.User.EmailAddress;
                    modelRecord.Fullname = Record.User.Fullname;
                    modelRecord.OrderDocuments = Record.OrderDocuments.Where(x => x.User.Role.Title.ToLower() == EnumRoleTypes.Designer).ToList();
                    modelRecord.WebsiteURL = ViewBag.WebsiteURL;
                    modelRecord.WebsiteURL = modelRecord.WebsiteURL.Replace("admin/", "");
                    modelRecord.OrderURL = ViewBag.WebsiteURL + "orders/view?id=" + modelRecord.Id;
                    var html = await this.RenderViewAsync("OrderEmailTemplate", modelRecord);
                    SendEmail(new MailObject { Database = dbContext, MailTo = modelRecord.EmailAddress, Subject = "Your order has been completed", Message = html });
                    OrderStatus record = new OrderStatus()
                    {
                        Id = Guid.NewGuid(),
                        DateTime = GetDateTime(),
                        OrderId = modelRecord.Id,
                        Status = EnumStatus.Delivered
                    };
                    dbContext.OrderStatus.Add(record);
                    dbContext.SaveChanges();
                    ajaxResponse.Success = true;
                    ajaxResponse.Message = "Email sent successfully";
                    ajaxResponse.Type = EnumJQueryResponseType.MessageAndRedirectWithDelay;
                    ajaxResponse.TargetURL = ViewBag.WebsiteURL + "orders";
                }
              
            }
            catch (Exception ex)
            {
                ajaxResponse.Message = "Email failed due to a technical error. Error code " + ex.Message;
            }
            return Json(ajaxResponse);
        }
    }
}
