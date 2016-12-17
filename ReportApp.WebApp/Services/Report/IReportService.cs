using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportApp.WebApp.Models;

namespace ReportApp.WebApp.Services.Report
{
    public interface IReportService
    {
        Task<RecordViewModel> AppendRecordAsync(RecordViewModel recordViewModel);

        Task<ReportViewModel> GetReportByDateAsync(DateTime date);

        Task<RecordsViewModel> GetRecordsByRangeDate(DateTime from, DateTime to);

        IEnumerable<TagViewModel> GetTagsByTerm(string tagTerm);
    }
}