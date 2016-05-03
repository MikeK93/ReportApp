using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ReportApp.WebApp.Models.Helpers;
using ReportApp.WebApp.Services.Report;

namespace ReportApp.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        [ValidateDate]
        public async Task<ActionResult> Index(int day, int month, int year)
        {
            var fullDate = new DateTime(year, month, day);
            ViewBag.CurrentDate = DateTime.Now.ToShortDateString();
            ViewBag.ViewedDate = fullDate.ToShortDateString();

            if (Request.IsAjaxRequest())
                return Json(await _service.GetRecordsByDateAsync(fullDate), JsonRequestBehavior.AllowGet);

            return View(await _service.GetRecordsByDateAsync(fullDate));
        }

        [NonAction]
        public RedirectToRouteResult ToAction(string action, object routeValues = null)
        {
            return RedirectToAction(action, typeof(ReportController).Name.Replace("Controller", string.Empty), routeValues);
        }
    }
}