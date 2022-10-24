namespace Bitak.Data.Common.Repositories
{
    using System;
    using System.Linq;

    using Bitak.Data.Common.Models;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);

        object Delete(Func<object, object> value);
    }
}
