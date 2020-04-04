using System;
using System.Threading;
using System.Threading.Tasks;
using works.ei8.Data.Tag.Common;

namespace works.ei8.Data.Tag.Application
{
    public interface IItemQueryService
    {
        Task<ItemData> GetItemById(string avatarId, Guid id, CancellationToken token = default);
    }
}
