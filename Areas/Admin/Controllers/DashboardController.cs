using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MrDigitizerV2.Helpers.ApplicationHelper;

namespace MrDigitizerV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/dashboard")]
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("getformats")]
        [HttpGet]
        public JsonResult GetFormats(string type)
        {
            return Json(dbContext.Formats.Where(x => x.Type.ToLower().Equals(type.ToLower()) && x.Status.Equals(EnumStatus.Enable) && !x.IsDeleted).Select(x => new { x.Id, x.Title }).ToList());
        }
    }
}
