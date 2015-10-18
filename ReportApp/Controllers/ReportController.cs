﻿using System;
using ReportApp.Services.Report;
using System.Linq;
using System.Web.Mvc;

namespace ReportApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;

        public ReportController(IReportService service) { _service = service; }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_service.GetRecordsByDate(DateTime.Now));
        }
    }
}