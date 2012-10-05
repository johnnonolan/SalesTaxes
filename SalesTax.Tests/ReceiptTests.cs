using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class ReceiptTests
    {
        [Test]
        public void Should_display_a_single_taxless_item()
        {
            var receipt = new Receipt();
            var shoppingBasket = new List<BasketItem> {new BasketItem {Price = 1.28m, Product = "Book", Quantity = 1}};
            var checkout = new CheckOut(receipt);
            checkout.CalculateTotal(shoppingBasket);
            Assert.That(receipt.Display(shoppingBasket), Is.EqualTo("1 book : 1.28 Sales Taxes: 0.00 Total: 1.28"));
        }
     }
}
