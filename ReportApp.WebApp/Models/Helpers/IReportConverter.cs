using System.Collections.Generic;
using ReportApp.API;
using ReportApp.Models;

namespace ReportApp.WebApp.Models.Helpers
{
    public interface IReportConverter
    {
        Record ConvertToRecord(RecordViewModel recordViewModel);

        RecordViewModel ConvertToViewModel(Record record);
        ReportViewModel ConvertToViewModel(IEnumerable<Record> records, double sum);

        string ConvertTagToString(Tag tag);
    }
}