using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Domain
{
    public class Record
    {
        public Record(DateTime date, string title, double moneySpent, IEnumerable<string> tags) : this(date, title, moneySpent, "no-description", tags) { }
        public Record(DateTime date, string title, double moneySpent, string description, IEnumerable<string> tags)
        {
            Date = date;
            Title = title;
            MoneySpent = moneySpent;
            Description = description;
            Tags = tags;
        }

        public DateTime Date { get; private set; }

        public string Title { get; private set; }

        public double MoneySpent { get; private set; }

        public IEnumerable<string> Tags { get; set; }

        public string Description { get; private set; }
    }
}