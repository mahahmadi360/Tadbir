using Ardalis.Specification;

namespace Mah.Tadbir.Specification
{
    public class TrueSpecification<T> : Specification<T>
    {
        public TrueSpecification()
        {
            Query.Where((entity) => true);
        }
    }
}
