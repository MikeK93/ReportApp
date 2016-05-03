using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ReportApp.Models;
using ReportApp.WebApp.Services.Report;

namespace ReportApp.WebApp.Controllers
{
    public class ReportApiController : Controller
    {
        private readonly IReportService _service;

        public ReportApiController(IReportService service)
        {
            _service = service;
        }

        [HttpPost]
        [ActionName("append-record")]
        public async Task<JsonResult> AppendRecord(RecordViewModel record)
        {
            return Json(await _service.AppendRecordAsync(record), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("tags")]
        public async Task<JsonResult> Tags(string tagTerm)
        {
            return Json(await _service.GetTagsByTermAsync(tagTerm));
        }

        [HttpGet]
        public async Task<JsonResult> GetByRange(DateTime from, DateTime to)
        {
            return Json(await _service.GetRecordsByRangeDate(from, to), JsonRequestBehavior.AllowGet);
        }
    }
}