using ReportApp.Models;
using System;
using System.Collections.Generic;

namespace ReportApp.Services.Report
{
    public interface IReportService
    {
        ReportViewModel GetRecordsByDate(DateTime date);
    }
}
