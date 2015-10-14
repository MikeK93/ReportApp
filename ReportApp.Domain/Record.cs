using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Domain
{
    public class Record
    {

        public Record(int id, DateTime date, double moneySpent) : this(id, date, "NoName", moneySpent, "NoDescription") { }

        public Record(int id, DateTime date, double moneySpent, string description) : this(id, date, "NoName", moneySpent, description) { }

        public Record(int id, DateTime date, string title, double moneySpent, string description)
        {
            Id = id;
            Date = date;
            Title = title;
            MoneySpent = moneySpent;
            Description = description;
        }

        public int Id { get; private set; }

        public DateTime Date { get; private set; }

        public string Title { get; private set; }

        public double MoneySpent { get; private set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Description { get; private set; }

        public override string ToString() => MoneySpent + " (" + Tags.Select(t => t.Name).ToString() + ")";
    }
}