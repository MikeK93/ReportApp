using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportApp.Models
{
    public class ReportViewModel
    {
        public ReportViewModel(IEnumerable<RecordViewModel> records, double sum)
        {
            Records = records;
            Sum = sum;
        }

        public IEnumerable<RecordViewModel> Records { get; private set; }
        public double Sum { get; private set; }
    }
}