using System;

namespace SalesTax
{
    public static class TaxExtensions
    {
        private static decimal roundToTwoDecimalPlaces(decimal n)
        {
            return Math.Ceiling(n * 100) / 100;
        }
        public static decimal TaxRound(this decimal amount)
        {
            amount = roundToTwoDecimalPlaces(amount);
            var removeChange = Math.Ceiling(amount);
            var change = removeChange - amount;
            if ((change * 100) % 5 == 0)
                return amount;
            return (amount + 0.01m).TaxRound();
        }
    }
}