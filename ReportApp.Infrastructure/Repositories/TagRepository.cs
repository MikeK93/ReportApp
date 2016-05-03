using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportApp.Infrastructure.Abstaction;

namespace ReportApp.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DBContext _context;

        public TagRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetTagsByTerm(string tagTerm)
        {
            return _context.Tags.Where(tag => tag.Name.ToLower().Contains(tagTerm.ToLower()));
        }

        public async Task<IEnumerable<Tag>> SaveAsync(IEnumerable<Tag> tags)
        {
            var result = new List<Tag>();

            foreach (var tag in tags)
            {
                var savedTag = _context.Tags.FirstOrDefault(t => t.Id == tag.Id) ?? await CreateTagAsync(tag);
                result.Add(savedTag);
            }

            return result;
        }

        private async Task<Tag> CreateTagAsync(Tag tag)
        {
            var newTag = _context.Tags.Create();
            newTag.Name = tag.Name;

            await _context.SaveChangesAsync();

            return newTag;
        }
    }
}
