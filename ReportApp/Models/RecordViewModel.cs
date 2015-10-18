using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportApp.Models
{
    public class RecordViewModel
    {
        public RecordViewModel(string title, double moneySpent, string decsription, string tags)
        {
            Title = title;
            MoneySpent = moneySpent;
            Decsription = decsription;
            Tags = tags;
        }

        public string Decsription { get; private set; }
        public double MoneySpent { get; private set; }
        public string Tags { get; private set; }
        public string Title { get; private set; }
    }
}