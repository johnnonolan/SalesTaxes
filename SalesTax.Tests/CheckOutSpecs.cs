using System.Collections.Generic;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class CheckOutSpecs
    {
        [Test]
        public void When_purchasing_a_taxable_item_tax_should_show_and_be_added_to_total()
        {
            var receipt = new Receipt();
            var checkOut = new CheckOut(receipt);
            var itemFactory = new ItemFactory();
            var taxableItem = new BasketItem{Item =itemFactory.CreateTaxableItem("taxable thing",3m) , Quantity = 1 };
            checkOut.CalculateTotal(new List<BasketItem> { taxableItem });
            Assert.That(checkOut.DisplayReceipt(), Is.EqualTo("1 taxable thing: 3.30 Sales Taxes: 0.30 Total: 3.30"));            
        }

        [Test] 
        public void When_purchasing_a_non_taxable_item_it_should_not_alter_total_price()
        {
            var receipt = new Receipt();
            var checkOut = new CheckOut(receipt);
            var itemFactory = new ItemFactory();
            var nonTaxableItem = new BasketItem { Item = itemFactory.CreateTaxExemptItem("Book", 1.29m), Quantity = 1 };
            checkOut.CalculateTotal(new List<BasketItem> { nonTaxableItem });
            Assert.That(checkOut.DisplayReceipt(), Is.EqualTo("1 book: 1.29 Sales Taxes: 0.00 Total: 1.29"));
        }

        [Test]
        public void When_purchasing__taxable_item_it_should_add_tax()
        {
            var receipt = new Receipt();              
            var checkOut = new CheckOut(receipt);
            var itemFactory = new ItemFactory();
            var nonTaxableItem = new BasketItem { Item = itemFactory.CreateTaxExemptItem("Book", 1.29m), Quantity = 1 };
            checkOut.CalculateTotal(new List<BasketItem> { nonTaxableItem });
            Assert.That(checkOut.DisplayReceipt(), Is.EqualTo("1 book: 1.29 Sales Taxes: 0.00 Total: 1.29"));
        }
    }
}
