using System;

namespace SalesTax
{
    public class BasketItem
    {
        public IItem Item { get; set; }

        public int Quantity { get; set; }
    }
}