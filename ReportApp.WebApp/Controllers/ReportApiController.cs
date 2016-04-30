﻿using System;
using System.Threading.Tasks;
using ReportApp.Services.Report;
using System.Web.Mvc;
using ReportApp.Models;

namespace ReportApp.Controllers
{
    public class ReportApiController : Controller
    {
        private readonly IReportService _service;

        public ReportApiController(IReportService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<JsonResult> AppendRecord(RecordViewModel record)
        {
            return Json(await _service.AppendRecordAsync(record), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetByRange(DateTime from, DateTime to)
        {
            return Json(await _service.GetRecordsByRangeDate(from, to), JsonRequestBehavior.AllowGet);
        }
    }
}