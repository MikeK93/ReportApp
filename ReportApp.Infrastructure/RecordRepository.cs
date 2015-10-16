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
            _records = new List<Record>();
        }

        public void Create(Record newRecord)
        {
            _records.Add(newRecord);
        }

        public IEnumerable<Record> GetAllByDate(DateTime date)
        {
            return _records.Where(r => r.Date == date).Select(r => r);
        }

        public Record GetById(int id)
        {
            return _records.FirstOrDefault(r => r.Id == id);
        }
    }
}
