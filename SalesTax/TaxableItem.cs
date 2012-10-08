namespace SalesTax
{
    public class TaxableItem : IItem
    {
        public string ProductName { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Tax { get; set; }

        internal TaxableItem(string productName, decimal netPrice)
        {
            ProductName = productName;
            NetPrice = netPrice;
            Tax = netPrice * 0.1m; //TODO: magic number
        }
    }
}