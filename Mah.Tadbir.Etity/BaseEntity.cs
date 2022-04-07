namespace Mah.Tadbir.Entity
{
    public abstract class BaseEntity<T> where T :struct
    {
        public T Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}
