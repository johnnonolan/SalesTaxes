using System.Collections.Generic;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class ReceiptTests
    {


        [Test]
        public void Should_display_multiple_taxless_items()
        {
            var receipt = new Receipt();
            var itemFactory = new ItemFactory();
            var shoppingBasket = new List<BasketItem> { new BasketItem { Item = itemFactory.CreateTaxExemptItem("Book", 1.28m), Quantity = 1 }, new BasketItem { Item = itemFactory.CreateTaxExemptItem("Medicine", 3.57m), Quantity = 1 } };
            var checkout = new CheckOut(receipt);
            checkout.CalculateTotal(shoppingBasket);
            Assert.That(receipt.Display(shoppingBasket), Is.EqualTo("1 book: 1.28 1 medicine: 3.57 Sales Taxes: 0.00 Total: 4.85")); 
        }

        [Test]
        public void Should_display_a_single_taxless_item()
        {
            var receipt = new Receipt();
            var itemFactory = new ItemFactory();
            var shoppingBasket = new List<BasketItem> {new BasketItem {Item = itemFactory.CreateTaxExemptItem("Book", 1.28m), Quantity = 1}};
            var checkout = new CheckOut(receipt);
            checkout.CalculateTotal(shoppingBasket);
            Assert.That(receipt.Display(shoppingBasket), Is.EqualTo("1 book: 1.28 Sales Taxes: 0.00 Total: 1.28"));
        }

        [Test]
        public void Basket_empty_Should_display_no_items()
        {
            var receipt = new Receipt();
            var shoppingBasket = new List<BasketItem> ();
            var checkout = new CheckOut(receipt);
            checkout.CalculateTotal(shoppingBasket);
            Assert.That(receipt.Display(shoppingBasket), Is.EqualTo("Sales Taxes: 0.00 Total: 0.00"));
        }
     }
}
