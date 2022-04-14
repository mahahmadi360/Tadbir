using System;
using System.Collections.Generic;

namespace Mah.Tadbir.Entity
{
    public class Invoice :BaseEntity
    {
        public Invoice()
        {
            InvoiceStuffs = new List<InvoiceStuff>();
        }
        public string CustomerName { get; set; }
        public string  Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public IEnumerable<InvoiceStuff> InvoiceStuffs { get; set; }
    }
}
