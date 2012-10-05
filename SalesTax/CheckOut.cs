using System.Collections.Generic;
using System.Linq;


namespace SalesTax
{
    public class CheckOut
    {
        readonly IDisplay _display;
        decimal _total; //primitive obsession?
        List<BasketItem> _shoppingBasket;
        public CheckOut(IDisplay display)
        {
            _display = display;            
        }

        public void CalculateTotal(List<BasketItem> shoppingBasket)
        {
           //todo: complete me
            _shoppingBasket = shoppingBasket;
            _total = shoppingBasket.Sum(s => s.Price * s.Quantity);
        }

        public string DisplayReceipt()
        {
            return _display.Display(_shoppingBasket);
        }
    }
}
