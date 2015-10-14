﻿using ReportApp.Services.Report;
using System.Web.Mvc;

namespace ReportApp.Controllers
{
    public class ReportController : Controller
    {
        private IReportService _service;

        public ReportController() : this(new ReportService()) { }
        public ReportController(IReportService service) { _service = service; }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}