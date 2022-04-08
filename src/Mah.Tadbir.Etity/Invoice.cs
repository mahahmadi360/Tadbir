using System;
using System.Collections.Generic;

namespace Mah.Tadbir.Entity
{
    public class Invoice :BaseEntity
    {
        public Invoice()
        {
            InvoiceStuffs = new List<InvoiceStuffs>();
        }
        public string CustomerName { get; set; }
        public string  Description { get; set; }
        public DateTime RegisteerDate { get; set; }
        public IEnumerable<InvoiceStuffs> InvoiceStuffs { get; set; }
    }
}
