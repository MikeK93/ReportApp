using ReportApp.Infrastructure.Abstaction;
using ReportApp.WebApp.Models;
using ReportApp.WebApp.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportApp.WebApp.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IRecordRepository _recordsRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IReportConverter _converter;
        private readonly IRecordValidator _recordValidator;

        public ReportService(IRecordRepository repository, IReportConverter converter, IRecordValidator recordValidator, ITagRepository tagRepository)
        {
            _recordsRepository = repository;
            _converter = converter;
            _recordValidator = recordValidator;
            _tagRepository = tagRepository;
        }

        public async Task<RecordViewModel> AppendRecordAsync(RecordViewModel recordViewModel)
        {
            if (!_recordValidator.IsDescriptionValid(recordViewModel.Description))
                throw new ArgumentException(string.Format("Invalid description: {0}", recordViewModel.Description));

            if (!_recordValidator.IsNameValid(recordViewModel.Title))
                throw new ArgumentException(string.Format("Invalid title: {0}", recordViewModel.Title));

            if (recordViewModel.Tags.Any(tag => !_recordValidator.IsNameValid(tag.Name)))
                throw new ArgumentException("Invalid tag");

            if (recordViewModel.Tags.Any(tag => tag.Id == 0))
            {
                var tagsToSave = recordViewModel.Tags.Select(_converter.ConvertToTag);
                var savedTags = await _tagRepository.SaveAsync(tagsToSave);
                recordViewModel.Tags = savedTags.Select(_converter.ConvertToViewModel);
            }

            var savedRecord = await _recordsRepository.SaveAsync(_converter.ConvertToRecord(recordViewModel));

            return _converter.ConvertToViewModel(savedRecord);
        }

        public async Task<ReportViewModel> GetReportByDateAsync(DateTime date)
        {
            if (date == null)
                throw new ArgumentException("Date cannot be null");

            var records = await _recordsRepository.GetAllByDateAsync(date);
            var sum = records.Sum(r => r.MoneySpent);

            return _converter.ConvertToViewModel(records, sum, date);
        }

        public async Task<RecordsViewModel> GetRecordsByRangeDate(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
            //if (from == null || to == null)
            //    throw new ArgumentException("Date cannot be null");

            //if (from > to)
            //    throw new ArgumentException(string.Format("Date from: '{0}' must be less than date to: '{1}'", from, to));

            //var records = await _recordsRepository.GetRecordsByDateRangeAsync(from, to);
            //var sum = records.Sum(r => r.MoneySpent);

            //return _converter.ConvertToViewModel(records, sum);
        }

        public IEnumerable<TagViewModel> GetTagsByTerm(string tagTerm)
        {
            var tags = _tagRepository.GetTagsByTerm(tagTerm);
            return tags.Select(tag => _converter.ConvertToViewModel(tag));
        }
    }
}