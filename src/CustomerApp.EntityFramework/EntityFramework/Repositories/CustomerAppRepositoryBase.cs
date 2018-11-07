using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace CustomerApp.EntityFramework.Repositories
{
    public abstract class CustomerAppRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<CustomerAppDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CustomerAppRepositoryBase(IDbContextProvider<CustomerAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class CustomerAppRepositoryBase<TEntity> : CustomerAppRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected CustomerAppRepositoryBase(IDbContextProvider<CustomerAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
