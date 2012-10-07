using System;

namespace SalesTax
{
    public class BasketItem : IProduct
    {
        public IItem Item { get; set; }

        public int Quantity { get; set; }

        public void AddTax()
        {
            throw new NotImplementedException();
        }
    }
}