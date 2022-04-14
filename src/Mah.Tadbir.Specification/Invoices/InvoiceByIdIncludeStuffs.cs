using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using Mah.Tadbir.Entity;

namespace Mah.Tadbir.Specification.Invoices
{
    public class InvoiceByIdIncludeStuffs :Specification<Invoice>
    {
        public InvoiceByIdIncludeStuffs( int id)
        {
            Query.Where(a => a.Id == id)
                .Include(a => a.InvoiceStuffs).ThenInclude(a=> a.Stuff);
        }
    }
}
