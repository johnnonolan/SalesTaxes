namespace SalesTax
{
    public class BasketItem
    {
        public IItem Item { get; private set; }

        public int Quantity { get; private set; }

        public BasketItem(IItem item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}