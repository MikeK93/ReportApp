using System;
using System.Collections.Generic;
using System.Linq;
using ReportApp.Infrastructure;
using ReportApp.Models;
using ReportApp.Domain;

namespace ReportApp.Services.Report
{
    public class ReportService : IReportService
    {
        private IRecordRepository _recordsRepository;

        public ReportService(IRecordRepository repository) { _recordsRepository = repository; }

        public RecordViewModel AppendRecord(string title, string description, IEnumerable<string> tags, double moneySpent, DateTime date)
        {
            var newRecord = new Record(date, title, moneySpent, description, tags);
            _recordsRepository.Create(newRecord);

            return new RecordViewModel(title, moneySpent, description, tags);
        }

        public ReportViewModel GetRecordsByDate(DateTime date)
        {
            var recordsViewModel = _recordsRepository
                                            .GetAllByDate(date)
                                            .Select(r => new RecordViewModel(r.Title, r.MoneySpent, r.Description, r.Tags));

            var sum = recordsViewModel.Sum(r => r.MoneySpent);

            return new ReportViewModel(recordsViewModel, sum);
        }
    }
}