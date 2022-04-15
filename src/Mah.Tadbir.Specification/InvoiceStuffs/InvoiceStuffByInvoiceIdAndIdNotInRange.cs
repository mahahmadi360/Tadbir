using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using Mah.Tadbir.Entity;

namespace Mah.Tadbir.Specification.Invoices
{
    public class InvoiceStuffByInvoiceIdAndIdNotInRange : Specification<InvoiceStuff>
    {
        public InvoiceStuffByInvoiceIdAndIdNotInRange(int invoiceId ,
            IEnumerable<int> invoiceStuffIds)
        {
            Query.Where(a=>a.InvoiceId == invoiceId && !invoiceStuffIds.Contains(a.Id));
        }
    }
}
