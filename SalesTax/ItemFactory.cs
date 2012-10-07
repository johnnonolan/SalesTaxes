namespace SalesTax
{
    public class ItemFactory
    {
        public IItem CreateTaxExemptItem(string productName, decimal cost, bool imported)
        {
            return new TaxExemptItem(productName, cost);
        }

        public IItem CreateTaxableItem(string productName, decimal cost)
        {
            return new TaxableItem(productName, cost);
        }
    }

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

    public interface IItem
    {
        string ProductName { get; set; }
        decimal GrossPrice { get; set; }
        decimal Tax { get; set; }
    }
}
