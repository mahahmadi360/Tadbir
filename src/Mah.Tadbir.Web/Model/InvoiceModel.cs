using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mah.Tadbir.Web.Model
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public IEnumerable<InvoiceStuffModel> InvoiceStuffs { get; set; }
    }
}
