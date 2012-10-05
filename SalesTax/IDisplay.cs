using System.Collections.Generic;

namespace SalesTax
{
    public interface IDisplay
    {
        string Display(List<BasketItem> basket);
    }
}