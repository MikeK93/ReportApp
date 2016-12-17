using System;
using System.Collections.Generic;
using System.Linq;
using ReportApp.Infrastructure;

namespace ReportApp.WebApp.Models.Helpers
{
    public class ReportConverter : IReportConverter
    {
        public Record ConvertToRecord(RecordViewModel viewModel)
        {
            return new Record
            {
                Date = viewModel.Date,
                Title = viewModel.Title,
                MoneySpent = viewModel.MoneySpent,
                Description = viewModel.Description,
                RecordTags = viewModel.Tags.Select(tag => new RecordTag
                {
                    Tag = ConvertToTag(tag)
                }).ToList()
            };
        }

        public Tag ConvertToTag(TagViewModel tagViewModel)
        {
            return new Tag
            {
                Id = tagViewModel.Id,
                Name = tagViewModel.Name,
                DateCreated = DateTime.Now
            };
        }

        public RecordViewModel ConvertToViewModel(Record record)
        {
            return new RecordViewModel
            {
                Date = record.Date,
                Description = record.Description,
                MoneySpent = record.MoneySpent,
                Title = record.Title,
                Tags = record.RecordTags.Select(t => new TagViewModel
                {
                    Id = t.TagId,
                    Name = CapitalizeFirstLatter(t.Tag.Name)
                })
            };
        }

        //public RecordsViewModel ConvertToViewModel(IEnumerable<Record> records, double sum)
        //{
        //    return new RecordsViewModel
        //    {
        //        Records = records.Select(ConvertToViewModel),
        //        Sum = sum
        //    };
        //}

        public TagViewModel ConvertToViewModel(Tag tag)
        {
            return new TagViewModel
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public ReportViewModel ConvertToViewModel(IEnumerable<Record> records, double sum, DateTime date)
        {
            var todayDate = new DateViewModel
            {
                FullDate = DateTime.Now.GetDateTimeFormats()[0],
                ShortDate = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year
            };
            var reportDate = new DateViewModel
            {
                FullDate = date.GetDateTimeFormats()[0],
                ShortDate = date.Month + "/" + date.Day + "/" + date.Year
            };
            var recordsViewModel = new RecordsViewModel
            {
                Records = records.Select(ConvertToViewModel),
                Sum = sum
            };

            return new ReportViewModel(todayDate, reportDate, recordsViewModel);
        }

        private static string CapitalizeFirstLatter(string value)
        {
            var res = value[0].ToString().ToUpper() + value.Substring(1, value.Length - 1);
            return res;
        }
    }
}