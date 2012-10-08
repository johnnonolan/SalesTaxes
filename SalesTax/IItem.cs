namespace SalesTax
{
    public interface IItem
    {
        string ProductName { get; set; }
        decimal NetPrice { get; set; }
        decimal Tax { get; set; }
    }
}