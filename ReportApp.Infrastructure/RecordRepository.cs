using System;
using System.Collections.Generic;
using ReportApp.Domain;

namespace ReportApp.Infrastructure
{
    public class RecordRepository : IRecordRepository
    {
        public void Create(Record newRecord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetAllByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Record GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
