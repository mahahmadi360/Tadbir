using System;
using System.Collections.Generic;

namespace Mah.Tadbir.Entity
{
    public class InvoiceInfo :BaseEntity
    {
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public int StuffCount { get; set; }

        public double TotalPrice { get; set; }

        public double BenefitPrice { get; set; }
    }
}
