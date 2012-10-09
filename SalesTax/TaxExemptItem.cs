using System;

namespace SalesTax
{
    public class TaxExemptItem : IItem
    {
        public string ProductName { get; private set; }
        public decimal NetPrice { get; private set; }
        public decimal Tax { get; private set; }
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
        }

        public decimal NetPrice
        {
            get { return _item.NetPrice; }          
        }

        
        public decimal Tax
        {
            get
            {
                var preRounding = (_item.Tax+_item.NetPrice * 0.05m);
                return preRounding.TaxRound();
            }
        }

    }

    public static class TaxExtensions
    {
        private static decimal roundToTwoDecimalPlaces(decimal n)
        {
            return Math.Ceiling(n * 100) / 100;
        }
        public static decimal TaxRound(this decimal amount)
        {
            amount = roundToTwoDecimalPlaces(amount);
            var removeChange = Math.Ceiling(amount);
            var change = removeChange - amount;
            if ((change * 100) % 5 == 0)
                return amount;
            return (amount + 0.01m).TaxRound();
        }
    }

}