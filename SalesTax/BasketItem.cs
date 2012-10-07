using System;

namespace SalesTax
{
    public class BasketItem : IProduct
    {
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public void AddTax()
        {
            throw new NotImplementedException();
        }
    }
}