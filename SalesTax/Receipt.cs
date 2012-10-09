using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTax
{
    public class Receipt : IDisplay
    {
        public string Display(List<BasketItem> basket)
        {
            var sb = new StringBuilder();
            foreach (var basketItem in basket)
            {
                sb.Append(basketItem.ToString());
            }
            sb.Append(basket.SummariseToString());
            return sb.ToString();
        }
    }
}