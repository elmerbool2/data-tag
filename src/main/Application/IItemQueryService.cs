using System;
using System.Threading;
using System.Threading.Tasks;
using ei8.Data.Tag.Common;

namespace ei8.Data.Tag.Application
{
    public interface IItemQueryService
    {
        Task<ItemData> GetItemById(Guid id, CancellationToken token = default);
    }
}
