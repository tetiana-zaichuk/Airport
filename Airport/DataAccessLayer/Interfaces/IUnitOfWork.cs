using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}
