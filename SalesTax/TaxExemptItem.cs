using System;

namespace SalesTax
{
    public class TaxExemptItem : IItem
    {
        public string ProductName { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Tax { get; set; }
        internal TaxExemptItem(string productName, decimal netPrice)
        {
            ProductName = productName;
            NetPrice = netPrice;
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

        public decimal NetPrice
        {
            get { return _item.NetPrice; }
            set { _item.NetPrice = value; }
        }

        
        public decimal Tax
        {
            get { return _item.Tax+_item.NetPrice * 0.05m; }
            set { _item.Tax = value; }
        }
    }
}