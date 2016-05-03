using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportApp.Infrastructure.Abstaction
{
    public interface IRecordRepository
    {
        Task<Record> SaveAsync(Record recordToSave);

        Task<IEnumerable<Record>> GetAllByDateAsync(DateTime date);

        Task<IEnumerable<Record>> GetRecordsByDateRangeAsync(DateTime from, DateTime to);

        Task<Tag> GetTagByNameAsync(string name);

        Task<IEnumerable<Tag>> GetAllTagsAsync();
    }
}