using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportApp.Infrastructure.Abstaction
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetTagsByTerm(string tagTerm);
        Task<IEnumerable<Tag>> SaveAsync(IEnumerable<Tag> tags);
    }
}