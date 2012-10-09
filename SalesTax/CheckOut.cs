using System.Collections.Generic;

namespace SalesTax
{
    public class CheckOut
    {
        readonly IDisplay _display;

        readonly List<BasketItem> _shoppingBasket = new List<BasketItem>();
        public CheckOut(IDisplay display)
        {
            _display = display;            
        }

        public void ScanItem(IItem item, int quantity)
        {
            _shoppingBasket.Add(new BasketItem {Item = item, Quantity = quantity});
        }

        public string DisplayReceipt()
        {
            return _display.Display(_shoppingBasket);
        }
    }
}
