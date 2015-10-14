using System;
using System.Collections.Generic;
using ReportApp.Infrastructure;
using ReportApp.Models;

namespace ReportApp.Services.Report
{
    public class ReportService : IReportService
    {
        private IRecordRepository _recordRepository;

        public ReportService() : this(new RecordRepository()) { } 
        public ReportService(IRecordRepository repository) { _recordRepository = repository; }

        public IEnumerable<RecordViewModel> GetRecordsByDate(DateTime date)
        {
            return null;
        }
    }
}