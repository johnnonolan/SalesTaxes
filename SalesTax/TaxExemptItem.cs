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
}