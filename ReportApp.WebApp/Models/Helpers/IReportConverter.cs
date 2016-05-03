using System.Collections.Generic;
using ReportApp.Infrastructure;
using ReportApp.Models;

namespace ReportApp.WebApp.Models.Helpers
{
    public interface IReportConverter
    {
        Record ConvertToRecord(RecordViewModel recordViewModel);

        Tag ConvertToTag(TagViewModel tagViewModel);

        RecordViewModel ConvertToViewModel(Record record);
        
        ReportViewModel ConvertToViewModel(IEnumerable<Record> records, double sum);

        TagViewModel ConvertToViewModel(Tag tag);
    }
}