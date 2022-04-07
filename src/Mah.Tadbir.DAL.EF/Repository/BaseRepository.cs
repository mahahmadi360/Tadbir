using Ardalis.GuardClauses;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Mah.Tadbir.Interface.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Mah.Tadbir.DAL.EF.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        protected readonly DbContext _DbContext;
        protected readonly DbSet<T> _Entities;

        public BaseRepository(DbContext dbContext)
        {
            _DbContext = dbContext;
            _Entities = _DbContext.Set<T>();

        }
        public void Add(T entity)
        {
            Guard.Against.Null(entity, nameof(entity));

            _Entities.Add(entity);
        }

        public void Delete(params T[] entities)
        {
            Guard.Against.Null(entities, nameof(entities));
            Guard.Against.Zero(entities.Length, nameof(entities));

            _Entities.RemoveRange(entities);
        }

        public IQueryable<T> GetData(ISpecification<T> specification)
        {
            return ApplySpecification(specification);
        }

        public Task<T> GetData(int id)
        {
           return _Entities.FindAsync(id).AsTask();
        }

        public void Update(T entity)
        {
            Guard.Against.Null(entity, nameof(entity));

            if (_DbContext.Entry(entity).State == EntityState.Detached)
            {
                _DbContext.Attach(entity);
                _DbContext.Update(entity);
            }
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return new SpecificationEvaluator<T>().GetQuery(_Entities.AsQueryable(), specification);
        }
    }
}
