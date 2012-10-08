using System;

namespace SalesTax
{
    public class TaxExemptItem : IItem
    {
        public string ProductName { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal Tax { get; set; }
        internal TaxExemptItem(string productName, decimal grossPrice)
        {
            ProductName = productName;
            GrossPrice = grossPrice;
            Tax = 0m;
        }
    }

    public class ImportedItem : IItem
    {

        public  ImportedItem(IItem item)
        {
            if (item == null) throw new ArgumentNullException("item");
                _item = item;
        }

        readonly IItem _item;

        public string ProductName
        {
            get { return _item.ProductName; }
            set { _item.ProductName = value; }
        }

        public decimal GrossPrice
        {
            get { return _item.GrossPrice; }
            set { _item.GrossPrice = value; }
        }

        
        public decimal Tax
        {
            get { return _item.Tax; }
            set { _item.Tax = value; }
        }
    }
}