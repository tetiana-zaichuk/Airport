using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataSeends Context;

        public UnitOfWork(DataSeends context)
        {
            Context = context;
        }

        public IRepository<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return new Repository<TEntity>(Context);
        }

    }
}
