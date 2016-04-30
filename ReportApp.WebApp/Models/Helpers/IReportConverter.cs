using System.Collections.Generic;
using ReportApp.API;

namespace ReportApp.Models.Helpers
{
    public interface IReportConverter
    {
        Record ConvertToRecord(RecordViewModel recordViewModel);

        RecordViewModel ConvertToViewModel(Record record);
        ReportViewModel ConvertToViewModel(IEnumerable<Record> records, double sum);

        string ConvertTagToString(Tag tag);
    }
}