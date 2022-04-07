using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mah.Tadbir.Interface.DAL.Repository
{
    public interface IBaseRepository<T> where T:class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(params T[] entities);

        IQueryable<T> GetData(ISpecification<T> specification);

        Task<T> GetData(int id);
    }
}
