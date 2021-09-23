using System.Threading.Tasks;

namespace UrlMapper.Domain.Repository
{
    public interface IReadRepository<TEntity>
    {
        Task<string> GetReqAsync(string req);
        
    }
}
