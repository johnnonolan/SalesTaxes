using System;

namespace SalesTax
{
    public class ImportedItem : IItem
    {

        readonly IItem _item;

        public  ImportedItem(IItem item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _item = item;
        }

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
            get
            {
                const decimal importTax = 0.05m;
                var preRounding = (_item.Tax+_item.NetPrice * importTax);
                return preRounding.TaxRound();
            }
            set { _item.Tax = value; }
        }

    }
}