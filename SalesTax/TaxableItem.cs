namespace SalesTax
{
    public class TaxableItem : IItem
    {
        public string ProductName { get; private set; }
        public decimal NetPrice { get; private set; }
        public decimal Tax { get; private set; }

        internal TaxableItem(string productName, decimal netPrice)
        {
            const decimal salesTax = 0.1m;
            ProductName = productName;
            NetPrice = netPrice;
            Tax = netPrice * salesTax;
        }
    }
}