using System;
using System.Collections.Generic;
using System.Linq;
using ReportApp.Infrastructure;
using ReportApp.Models;

namespace ReportApp.Services.Report
{
    public class ReportService : IReportService
    {
        private IRecordRepository _recordsRepository;

        public ReportService(IRecordRepository repository) { _recordsRepository = repository; }

        public ReportViewModel GetRecordsByDate(DateTime date)
        {
            var recordsViewModel = _recordsRepository
                                            .GetAllByDate(date)
                                            .Select(r =>
                                                new RecordViewModel(r.Title, r.MoneySpent, r.Description, r.Tags.ToString())
                                            );

            var sum = recordsViewModel.Sum(r => r.MoneySpent);

            return new ReportViewModel(recordsViewModel, sum);
        }
    }
}