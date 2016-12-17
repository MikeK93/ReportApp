using ReportApp.WebApp.Models.Helpers;
using ReportApp.WebApp.Services.Report;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

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
            var date = new DateTime(year, month, day);
            var viewModel = await _service.GetReportByDateAsync(date);

            if (Request.IsAjaxRequest())
                return Json(viewModel, JsonRequestBehavior.AllowGet);

            return View(viewModel);
        }

        [NonAction]
        public RedirectToRouteResult ToAction(string action, object routeValues = null)
        {
            return RedirectToAction(action, typeof(ReportController).Name.Replace("Controller", string.Empty), routeValues);
        }
    }
}