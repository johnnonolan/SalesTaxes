namespace SalesTax
{
    public interface IItem
    {
        string ProductName { get; set; }
        decimal GrossPrice { get; set; }
        decimal Tax { get; set; }

    }
}