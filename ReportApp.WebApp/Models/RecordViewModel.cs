using System;
using System.Collections.Generic;
using ReportApp.WebApp.Models;

namespace ReportApp.Models
{
    [Serializable]
    public class RecordViewModel
    {
        public RecordViewModel() { }

        public RecordViewModel(DateTime date, string title, double moneySpent, string description, IEnumerable<TagViewModel> tags)
        {
            Date = date;
            Title = title;
            MoneySpent = moneySpent;
            Description = description;
            Tags = tags;
        }

        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double MoneySpent { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}