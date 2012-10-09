namespace SalesTax
{
    public class ItemFactory
    {
        public IItem CreateTaxExemptItem(string productName, decimal cost)
        {
            return new TaxExemptItem(productName, cost);
        }

        public IItem CreateTaxableItem(string productName, decimal cost)
        {
            return new TaxableItem(productName, cost);
        }

        public IItem ImportTaxExemptItem(string productName, decimal cost)
        {
            return new ImportedItem(new TaxExemptItem(productName, cost));
        }

        public IItem ImportTaxableItem(string productName, decimal cost)
        {
            return new ImportedItem(new TaxableItem(productName, cost));
        }
    }
}
