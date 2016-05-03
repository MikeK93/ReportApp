using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportApp.API.RecordRepository;
using ReportApp.Models;
using ReportApp.WebApp.Models;
using ReportApp.WebApp.Models.Helpers;

namespace ReportApp.WebApp.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IRecordRepository _recordsRepository;
        private readonly IReportConverter _converter;
        private readonly IRecordValidator _recordValidator;

        public ReportService(IRecordRepository repository, IReportConverter converter, IRecordValidator recordValidator)
        {
            _recordsRepository = repository;
            _converter = converter;
            _recordValidator = recordValidator;
        }

        public async Task<RecordViewModel> AppendRecordAsync(RecordViewModel recordViewModel)
        {
            if (!_recordValidator.IsDescriptionValid(recordViewModel.Description))
                throw new ArgumentException(string.Format("Invalid description: {0}", recordViewModel.Description));

            if (!_recordValidator.IsNameValid(recordViewModel.Title))
                throw new ArgumentException(string.Format("Invalid title: {0}", recordViewModel.Title));

            if (recordViewModel.Tags.Any(tag => !_recordValidator.IsNameValid(tag)))
                throw new ArgumentException("Invalid tag");

            foreach (var tag in recordViewModel.Tags)
            {
                var tagExist = await IsTagExistAsync(tag.ToLower());
                if (!tagExist)
                    throw new ArgumentException("Tag does not exist");
            }

            var savedRecord = await _recordsRepository.SaveAsync(_converter.ConvertToRecord(recordViewModel));

            return _converter.ConvertToViewModel(savedRecord);
        }

        public async Task<ReportViewModel> GetRecordsByDateAsync(DateTime date)
        {
            if (date == null)
                throw new ArgumentException("Date cannot be null");

            var records = await _recordsRepository.GetAllByDateAsync(date);
            var sum = records.Sum(r => r.MoneySpent);

            return _converter.ConvertToViewModel(records, sum);
        }

        public async Task<ReportViewModel> GetRecordsByRangeDate(DateTime from, DateTime to)
        {
            if (from == null || to == null)
                throw new ArgumentException("Date cannot be null");

            if (from > to)
                throw new ArgumentException(string.Format("Date from: '{0}' must be less than date to: '{1}'", from, to));

            var records = await _recordsRepository.GetRecordsByDateRangeAsync(from, to);
            var sum = records.Sum(r => r.MoneySpent);

            return _converter.ConvertToViewModel(records, sum);
        }

        public async Task<IEnumerable<string>> GetTagsAsync()
        {
            var tags = await _recordsRepository.GetAllTagsAsync();
            return tags.Select(_converter.ConvertTagToString);
        }

        private async Task<bool> IsTagExistAsync(string name)
        {
            var tag = await _recordsRepository.GetTagByNameAsync(name);
            return tag != null;
        }
    }
}