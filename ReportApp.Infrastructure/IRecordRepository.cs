using ReportApp.Domain;
using System;
using System.Collections.Generic;

namespace ReportApp.Infrastructure
{
    public interface IRecordRepository
    {
        void Create(Record newRecord);

        IEnumerable<Record> GetAllByDate(DateTime date);
    }
}
