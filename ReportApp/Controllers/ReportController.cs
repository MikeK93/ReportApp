using System;
using ReportApp.Services.Report;
using System.Linq;
using System.Web.Mvc;
using ReportApp.Models.Helpers;

namespace ReportApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;

        public ReportController(IReportService service) { _service = service; }

        [HttpGet]
        [ValidateDate]
        public ActionResult Index(int day, int month, int year)
        {
            var fullDate = new DateTime(year, month, day);
            ViewBag.CurrentDate = DateTime.Now.ToShortDateString();
            ViewBag.ViewedDate = fullDate.ToShortDateString();

            return View(_service.GetRecordsByDate(fullDate));
        }

        [HttpGet]
        public ActionResult WrongDate()
        {
            return View();
        }

        [NonAction]
        public RedirectToRouteResult ToAction(string action, object routeValues = null)
        {
            return RedirectToAction(action, typeof(ReportController).Name.Replace("Controller", string.Empty), routeValues);
        }
    }
}