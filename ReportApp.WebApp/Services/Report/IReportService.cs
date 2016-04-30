using ReportApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportApp.Services.Report
{
    public interface IReportService
    {
        Task<RecordViewModel> AppendRecordAsync(RecordViewModel recordViewModel);

        Task<ReportViewModel> GetRecordsByDateAsync(DateTime date);

        Task<ReportViewModel> GetRecordsByRangeDate(DateTime from, DateTime to);

        Task<IEnumerable<string>> GetTagsAsync();
    }
}