using System;
using System.ComponentModel.DataAnnotations;

namespace Mah.Tadbir.Web.Model
{
    public class InvoiceStuffModel
    {
        public int Id { get; set; }

        [Required]
        public int InvoiceId { get; set; }

        [Required]
        public int StuffId { get; set; }
        public string StuffName { get; set; }

        private double _StuffQuantity;

        [Required]
        [Range(0, double.MaxValue)]
        public double StuffQuantity
        {
            get { return _StuffQuantity; }
            set
            {
                _StuffQuantity = value;
            }
        }


        private double _StuffPrice;
        [Required]
        [Range(0, double.MaxValue)]
        public double StuffPrice
        {
            get
            {
                return _StuffPrice;
            }
            set
            {
                _StuffPrice = value;
            }
        }

        private double _OffPercent;
        [Required]
        [Range(0, 100)]
        public double OffPercent
        {
            get { return _OffPercent; }
            set
            {
                _OffPercent = value;
            }
        }
    }
}