using System;
using System.Collections.Generic;
using System.Linq;
using ReportApp.Domain;

namespace ReportApp.Infrastructure
{
    public class RecordRepository : IRecordRepository
    {
        private readonly List<Record> _records;

        public RecordRepository()
        {
            _records = new List<Record> {
                new Record(DateTime.Now, "House", 100500, "Bought a house", new [] { "buy", "house", "big-amount" }),
                new Record(DateTime.Now, "Food", 500, new [] { "food", "eat" })
            };
        }

        public void Create(Record newRecord)
        {
            _records.Add(newRecord);
        }

        public IEnumerable<Record> GetAllByDate(DateTime date)
        {
            return _records.Where(r => r.Date.ToShortDateString() == date.ToShortDateString());//.Select(r => r);
        }
    }
}