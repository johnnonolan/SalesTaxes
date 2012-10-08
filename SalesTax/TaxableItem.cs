namespace SalesTax
{
    public class TaxableItem : IItem
    {
        public string ProductName { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal Tax { get; set; }

        internal TaxableItem(string productName, decimal grossPrice)
        {
            ProductName = productName;
            GrossPrice = grossPrice * 1.1m;
            Tax = grossPrice * 0.1m; //TODO: magic number
        }
    }
}