using System;

namespace Mah.Tadbir.Entity
{
    public class Invoice :BaseEntity
    {
        public string CustomerName { get; set; }
        public string  Description { get; set; }
        public DateTime RegisteerDate { get; set; }
    }
}
