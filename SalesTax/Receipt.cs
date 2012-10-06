using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTax
{
    public class Receipt : IDisplay
    {
        public string Display(List<BasketItem> basket)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var basketItem in basket)
            {
                sb.Append(string.Format("{0} {1} : {2} ", basketItem.Quantity,
                                            basketItem.Product.ToLower(), basketItem.Price));
            }
            sb.Append(string.Format("Sales Taxes: 0.00 Total: {0:0.00}",basket.Sum(x => x.Price)));
            return sb.ToString();
        }
    }
}