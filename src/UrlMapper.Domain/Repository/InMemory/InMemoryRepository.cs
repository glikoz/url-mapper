using System.Collections.Generic;
using System.Threading.Tasks;

namespace UrlMapper.Domain.Repository.InMemory
{
    public class InMemoryRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
    {
        private readonly Dictionary<string, string> db;

        public InMemoryRepository()
        {
            db = new Dictionary<string, string>();
        }

        public async Task<string> GetReqAsync(string req)
        {
            db.TryGetValue(req, out string value);
            return await Task.FromResult(value);
        }

        public async Task<bool> StoreAsync(string req, string res)
        {
            return await Task.FromResult(db.TryAdd(req, res));
        }
    }
}
