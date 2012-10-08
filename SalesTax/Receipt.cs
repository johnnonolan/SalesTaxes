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
                sb.Append(string.Format("{0} {1}: {2:0.00} ", basketItem.Quantity,
                                            basketItem.Item.ProductName.ToLower(), basketItem.Item.NetPrice+basketItem.Item.Tax));
            }
            sb.Append(string.Format("Sales Taxes: {0:0.00} Total: {1:0.00}",basket.Sum(x => x.Item.Tax), basket.Sum(x => x.Item.NetPrice+x.Item.Tax)));
            return sb.ToString();
        }
    }
}