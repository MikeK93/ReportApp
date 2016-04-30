using System.Collections.Generic;
using ReportApp.API;
using System.Linq;

namespace ReportApp.Models.Helpers
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
                RecordTags = viewModel.Tags.Select(t => new RecordTag { Tag = new Tag { Name = t.Name } }).ToList()
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
                Tags = record.RecordTags.Select(t => new TagViewModel { Name = CapitalizeFirstLatter(t.Tag.Name) })
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