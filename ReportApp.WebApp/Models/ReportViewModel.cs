namespace ReportApp.WebApp.Models
{
    public class ReportViewModel
    {
        public ReportViewModel(DateViewModel today, DateViewModel report, RecordsViewModel records)
        {
            TodayDate = today;
            ReportDate = report;
            RecordsViewModel = records;
        }

        public DateViewModel TodayDate { get; private set; }

        public DateViewModel ReportDate { get; private set; }

        public RecordsViewModel RecordsViewModel { get; private set; }
    }
}