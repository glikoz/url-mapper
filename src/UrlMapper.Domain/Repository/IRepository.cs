namespace UrlMapper.Domain.Repository
{
    public interface IRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity>
    {
    }
}
