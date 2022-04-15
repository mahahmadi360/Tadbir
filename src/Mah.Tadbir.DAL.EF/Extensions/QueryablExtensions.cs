using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using System.Linq;

namespace Mah.Tadbir.DAL.EF.Extensions
{
    public static class QueryablExtensions
    {
        public static IQueryable<S> ApplySpecification<S>(this IQueryable<S> entities,
            ISpecification<S> specification) where S : class
        {
            return new SpecificationEvaluator<S>().GetQuery(entities, specification);
        }
    }
}
