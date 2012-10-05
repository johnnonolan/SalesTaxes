using System.Collections.Generic;


namespace SalesTax
{
    public class CheckOut
    {
        readonly IDisplay _display;

        public CheckOut(IDisplay display)
        {
            _display = display;            
        }

        public void CalculateTotal(List<BasketItem> shoppingBasket)
        {
           //todo: complete me
        }

        public string DisplayReceipt()
        {
            return _display.Display(this);
        }
    }
}
