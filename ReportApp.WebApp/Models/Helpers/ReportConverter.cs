using System.Collections.Generic;
using System.Linq;
using ReportApp.API;
using ReportApp.Models;

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
                    Tag = new Tag { Name = tag }
                }).ToList()
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
                Tags = record.RecordTags.Select(t => CapitalizeFirstLatter(t.Tag.Name))
            };
        }

        public ReportViewModel ConvertToViewModel(IEnumerable<Record> records, double sum)
        {
            return new ReportViewModel
            {
                Records = records.Select(ConvertToViewModel),
                Sum = sum
            };
        }

        public string ConvertTagToString(Tag tag)
        {
            return CapitalizeFirstLatter(tag.Name);
        }

        private static string CapitalizeFirstLatter(string value)
        {
            var res = value[0].ToString().ToUpper() + value.Substring(1, value.Length - 1);
            return res;
        }
    }
}