using ReportApp.Models;
using System;
using System.Collections.Generic;

namespace ReportApp.Services.Report
{
    public interface IReportService
    {
        IEnumerable<RecordViewModel> GetRecordsByDate(DateTime date);
    }
}
