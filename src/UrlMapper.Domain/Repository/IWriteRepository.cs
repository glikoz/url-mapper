using System.Threading.Tasks;

namespace UrlMapper.Domain.Repository
{
    public interface IWriteRepository<TEntity>
    {
        Task<bool> StoreAsync(string req, string res);
    }
}