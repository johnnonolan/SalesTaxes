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

        public override string ToString()
        {
            return string.Format("{0} {1}: {2:0.00} ", Quantity,
                                 Item.ProductName.ToLower(), Item.NetPrice + Item.Tax);
        }
    }
}