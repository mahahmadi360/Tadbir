using System;

namespace Mah.Tadbir.Entity
{
    public class InvoiceStuffs : BaseEntity
    {
        public int InvoiceId { get; set; }
        public int StuffId { get; set; }
        public Stuff Stuff { get; set; }

        private double _StuffQuantity;

        public double StuffQuantity
        {
            get { return _StuffQuantity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                            "Stuff quantity must be greater than 0.0");
                }
                _StuffQuantity = value;
            }
        }


        private double _StuffPrice;
        public double StuffPrice
        {
            get
            {
                return _StuffPrice;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                            "Stuff Price must be greater than 0.0");
                }
                _StuffPrice = value;
            }
        }

        private double _OffPercent;

        public double OffPercent
        {
            get { return _OffPercent; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value",
                                "Off Percent must be greater than 0.0");
                if (value > 100)
                    throw new ArgumentOutOfRangeException("value",
                                "Off Percent must be less than 100");
                _OffPercent = value;
            }
        }


    }
}
