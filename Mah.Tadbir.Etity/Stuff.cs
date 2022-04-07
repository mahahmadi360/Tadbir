using System;

namespace Mah.Tadbir.Entity
{
    public class Stuff : BaseEntity
    {
        public string Name { get; set; }
        private double _price;

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                            "The value must be greater than 0.0");
                }
                _price = value;
            }
        }
    }
}
