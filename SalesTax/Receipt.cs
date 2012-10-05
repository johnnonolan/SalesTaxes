using System.Collections.Generic;
using System.Linq;

namespace SalesTax
{
    public class Receipt : IDisplay
    {
        public string Display(List<BasketItem> basket)
        {
            
            var item = basket.First();
            return string.Format("{0} {1} : {2} Sales Taxes: 0.00 Total: {2}",item.Quantity,item.Product.ToLower(),item.Price);
        }
    }
}