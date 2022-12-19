using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrDigitizerV2.Models;
using static MrDigitizerV2.Helpers.ApplicationHelper;
using System.IO;
using System.Security.Claims;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace MrDigitizerV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/registration")]
    public class RegistrationController : Controller
    {
        IWebHostEnvironment webHostEnvironment;
        MrdigitizerV2Context dbContext;
        public RegistrationController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            dbContext = new MrdigitizerV2Context();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.WebsiteURL = GetSettingContentByName(dbContext, Website_URL_Key) + "Admin/";
            base.OnActionExecuting(filterContext);
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("save")]
        [HttpPost]
        public async Task<JsonResult> SaveAsync(Users modelRecord)
        {
            AjaxResponse ajaxResponse = new AjaxResponse();
            ajaxResponse.Success = false;
            ajaxResponse.Type = EnumJQueryResponseType.MessageOnly;
            ajaxResponse.Message = "Invalid Request";
            try
            {
                bool isAbleToAddOrUpdate = true;
                var RecordAlreadyExist = dbContext.Users.Any(x => x.EmailAddress.ToLower().Equals(modelRecord.EmailAddress.ToLower()) && x.Status.Equals(EnumStatus.Enable));
                if (RecordAlreadyExist)
                {
                    isAbleToAddOrUpdate = false;
                    ajaxResponse.Message = "The account with this email is already registered";
                }
                if (isAbleToAddOrUpdate)
                {
                    if (modelRecord.Id == Guid.Empty)
                    {                       
                        if (modelRecord.File != null)
                            modelRecord.ProfileImagePath = UploadFileToFolder(modelRecord.File, Path.Combine(webHostEnvironment.WebRootPath, EnumFileUploadFolder.ProfileImage));                           
                        modelRecord.Id = Guid.NewGuid();
                        modelRecord.RoleId = dbContext.Roles.FirstOrDefault(x => x.Title.ToLower().Equals("member")).Id;
                        modelRecord.Password = Encrypt(modelRecord.Password);
                        modelRecord.PasswordRecoveryCode = Encrypt(RandomString(6));
                        modelRecord.IsDeleted = false;
                        modelRecord.Status = EnumStatus.Disable;
                        modelRecord.CreatedDateTime = GetDateTime(dbContext);
                        modelRecord.UtccreatedDateTime = GetUtcDateTime();
                        modelRecord.CreatedBy = modelRecord.Id;
                        dbContext.Users.Add(modelRecord);
                        dbContext.SaveChanges();
                        var html = await this.RenderViewAsync("ConfirmationEmailTemplate", new EmailMeta
                        { 
                            Fullname = modelRecord.Fullname,
                            WebsiteURL = ViewBag.WebsiteURL,
                            URL = ViewBag.WebsiteURL + "confirmation?token=" + modelRecord.PasswordRecoveryCode
                        });
                        SendEmail(new MailObject { Database = dbContext, MailTo = modelRecord.EmailAddress, Subject = "Account verification", Message = html });
                        ajaxResponse.Type = EnumJQueryResponseType.DataOnly;                           
                        ajaxResponse.Data = $"<div class='alert alert-success'><b>Registration successful.</b> check your email address for verification and <a href='{ViewBag.WebsiteURL}'>click here for login</a></div>";
                        ajaxResponse.Success = true;
                    }
                        
                }
                
            }
            catch (Exception ex)
            {
                ajaxResponse.Message = "Registration failed due to a technical error. Error code: " + ex.Message;
            }
            return Json(ajaxResponse);
        }
    }
}
