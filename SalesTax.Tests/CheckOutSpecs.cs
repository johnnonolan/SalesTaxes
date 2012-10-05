using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class CheckOutSpecs
    {
        [Test] 
        public void When_purchasing_a_non_taxible_item_it_should_not_alter_price()
        {
            var checkOut = new CheckOut(new Receipt());
            var nonTaxableItem = new BasketItem {Price = 1.29m, Product = "Book", Quantity = 1};
            checkOut.CalculateTotal(new List<BasketItem> { nonTaxableItem });
            Assert.That(checkOut.DisplayReceipt(), Is.EqualTo("1 book : 1.29 Sales Taxes: 0.00 Total: 0.00"));
        }

    }
}
