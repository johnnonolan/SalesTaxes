namespace SalesTax
{
    public interface IItem
    {
        string ProductName { get; }

        decimal NetPrice { get; }

        decimal Tax { get; }
    }
}