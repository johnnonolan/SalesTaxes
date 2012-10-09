using System.Collections.Generic;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class CheckOutSpecs
    {
        Receipt _receipt ;
        CheckOut _checkOut;
        ItemFactory _itemFactory;

        [SetUp]
        public void SetUp()
        {
             _receipt = new Receipt();
            _checkOut = new CheckOut(_receipt);
            _itemFactory = new ItemFactory();
        }

        [Test]
        public void When_purchasing_a_taxable_item_tax_should_show_and_be_added_to_total()
        {                    
            var taxableItem = _itemFactory.CreateTaxableItem("taxable thing", 3m);
            _checkOut.ScanItem(taxableItem,1);            
            Assert.That(_checkOut.DisplayReceipt(), Is.EqualTo("1 taxable thing: 3.30 Sales Taxes: 0.30 Total: 3.30"));            
        }

        [Test] 
        public void When_purchasing_a_non_taxable_item_it_should_not_alter_total_price()
        {
            var nonTaxableItem = _itemFactory.CreateTaxExemptItem("Book", 1.29m);
            _checkOut.ScanItem(nonTaxableItem,1);
            Assert.That(_checkOut.DisplayReceipt(), Is.EqualTo("1 book: 1.29 Sales Taxes: 0.00 Total: 1.29"));
        }

        [Test]
        public void When_purchasing__taxable_item_it_should_add_tax()
        {
            var nonTaxableItem = _itemFactory.CreateTaxExemptItem("Book", 1.29m);
            _checkOut.ScanItem(nonTaxableItem,1);
            Assert.That(_checkOut.DisplayReceipt(), Is.EqualTo("1 book: 1.29 Sales Taxes: 0.00 Total: 1.29"));
        }
    }
}
