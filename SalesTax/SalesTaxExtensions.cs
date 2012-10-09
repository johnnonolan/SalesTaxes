using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax
{
    public static class SalesTaxExtensions
    {
        private static decimal RoundToTwoDecimalPlaces(decimal n)
        {
            return Math.Ceiling(n * 100) / 100;
        }
        public static decimal TaxRound(this decimal amount)
        {
            amount = RoundToTwoDecimalPlaces(amount);
            var removeChange = Math.Ceiling(amount);
            var change = removeChange - amount;
            if ((change * 100) % 5 == 0)
                return amount;
            return (amount + 0.01m).TaxRound();
        }

        public static string SummariseToString(this List<BasketItem> basket)
        {
            return string.Format("Sales Taxes: {0:0.00} Total: {1:0.00}", basket.Sum(x => x.Item.Tax),
                                 basket.Sum(x => x.Item.NetPrice + x.Item.Tax));
        }
    }
}