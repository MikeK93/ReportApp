using System;
using ReportApp.Services.Report;
using System.Web.Mvc;
using ReportApp.Models.Helpers;
using System.Collections.Generic;
using ReportApp.Models;

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

            if (Request.IsAjaxRequest())
                return PartialView("ListRecords", _service.GetRecordsByDate(fullDate));

            return View(_service.GetRecordsByDate(fullDate));
        }

        [HttpGet]
        //[AjaxOnly]
        public ActionResult AppendRecord(string title, double moneySpent, string description)//, IEnumerable<string> tags, DateTime date)
        {
            return PartialView("Record", _service.AppendRecord(title, description, new string[] { "test", "tag" }/*tags*/, moneySpent, /*date*/ DateTime.Now));
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