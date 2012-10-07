namespace SalesTax
{
    public class ItemFactory
    {
        public Item CreateTaxExemptItem(string productName, decimal cost)
        {
            return new TaxExemptItem(productName, cost);
        }

        public Item CreateTaxableItem(string productName, decimal cost)
        {
            return new TaxableItem(productName, cost);
        }
    }

    public class TaxableItem : Item
    {
        public TaxableItem(string productName, decimal cost)
            : base(productName, cost * 1.1m)
        {
            Tax = cost * 0.1m;
        }
    }

    public class TaxExemptItem : Item
    {
        public TaxExemptItem(string productName, decimal cost) : base(productName,cost)
        {
            
        }
    }

    public abstract class Item
    {
        public string ProductName { get; private set; }
        public decimal GrossPrice { get; private set; }
        public decimal Tax { get; protected set; }

        protected Item(string productName, decimal cost)
        {
            ProductName = productName;
            GrossPrice = cost;

        }
    }
}
