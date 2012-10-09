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
        }

        public decimal NetPrice
        {
            get { return _item.NetPrice; }
        }
        
        public decimal Tax
        {
            get
            {
                const decimal importTax = 0.05m;
                var preRounding = (_item.Tax+_item.NetPrice * importTax);
                return preRounding.TaxRound();
            }
        }

    }
}