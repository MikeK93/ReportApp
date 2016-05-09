using System;
using System.Collections.Generic;

namespace ReportApp.WebApp.Models
{
    [Serializable]
    public class ReportViewModel
    {
        public ReportViewModel() { }

        public ReportViewModel(IEnumerable<RecordViewModel> records, double sum)
        {
            Records = records;
            Sum = sum;
        }

        public IEnumerable<RecordViewModel> Records { get; set; }
        public double Sum { get; set; }
    }
}