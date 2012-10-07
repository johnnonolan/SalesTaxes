using System.Collections.Generic;
using System.Linq;

namespace SalesTax
{
    public class CheckOut
    {
        readonly IDisplay _display;

        List<BasketItem> _shoppingBasket;
        public CheckOut(IDisplay display)
        {
            _display = display;            
        }

        public void CalculateTotal(List<BasketItem> shoppingBasket)
        {
           //todo: commenting out of the sum shows that this isn't needed. calc total is not needed.
            _shoppingBasket = shoppingBasket;
        }

        public string DisplayReceipt()
        {
            return _display.Display(_shoppingBasket);
        }
    }
}
