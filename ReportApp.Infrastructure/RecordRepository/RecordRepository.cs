using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ReportApp.API.RecordRepository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly DBContext _context;
        
        public RecordRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<Record> SaveAsync(Record recordToSave)
        {
            var record = CreateRecord(recordToSave);

            record.RecordTags = await GetRecordsTagsAsync(recordToSave.RecordTags, record.Id);

            await _context.SaveChangesAsync();

            return record;
        }

        public async Task<IEnumerable<Record>> GetAllByDateAsync(DateTime date)
        {
            return await _context.Records.Where(r => r.Date == date).ToListAsync();
        }

        public async Task<Tag> GetTagByNameAsync(string name)
        {
            return await _context.Tags.FirstOrDefaultAsync(t => t.Name == name);
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        private Record CreateRecord(Record recordToSave)
        {
            var record = _context.Records.Create();

            record.Date = recordToSave.Date;
            record.Title = recordToSave.Title;
            record.MoneySpent = recordToSave.MoneySpent;
            record.Description = recordToSave.Description;
            record.DateCreated = DateTime.Now;

            _context.Records.Add(record);

            return record;
        }

        private async Task<ICollection<RecordTag>> GetRecordsTagsAsync(IEnumerable<RecordTag> recordTags, int recordId)
        {
            var res = new List<RecordTag>();

            foreach (var recordTag in recordTags)
            {
                res.Add(await CreateRecordTag(recordId, recordTag.Tag.Name));
            }

            return res;
        }

        private async Task<RecordTag> CreateRecordTag(int recordId, string tagName)
        {
            var tag = await GetTagByNameAsync(tagName);
            var newRecordTag = _context.RecordTags.Create();
            newRecordTag.TagId = tag.Id;
            newRecordTag.Tag = tag;
            newRecordTag.RecordId = recordId;

            _context.RecordTags.Add(newRecordTag);

            return newRecordTag;
        }

        public async Task<IEnumerable<Record>> GetRecordsByDateRangeAsync(DateTime from, DateTime to)
        {
            return await _context.Records.Where(r => r.Date >= from && r.Date <= to).ToListAsync();
        }
    }
}