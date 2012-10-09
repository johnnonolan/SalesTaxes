using System.Collections.Generic;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class ReceiptTests
    {
        IDisplay _receipt;
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
        public void Should_display_multiple_taxless_items()
        {           
            var book = _itemFactory.CreateTaxExemptItem("Book", 1.28m);
            var medicine = _itemFactory.CreateTaxExemptItem("Medicine", 3.75m);
            _checkOut.ScanItem(book,1);
            _checkOut.ScanItem(medicine,1);
            Assert.That(_checkOut.DisplayReceipt(), Is.EqualTo("1 book: 1.28 1 medicine: 3.75 Sales Taxes: 0.00 Total: 5.03")); 
        }

        [Test]
        public void Should_display_a_single_taxless_item()
        {
            var book = _itemFactory.CreateTaxExemptItem("Book", 1.28m);           
            _checkOut.ScanItem(book,1);
            Assert.That(_checkOut.DisplayReceipt(), Is.EqualTo("1 book: 1.28 Sales Taxes: 0.00 Total: 1.28"));
        }

        [Test]
        public void Basket_empty_Should_display_no_items()
        {
            Assert.That(_checkOut.DisplayReceipt(), Is.EqualTo("Sales Taxes: 0.00 Total: 0.00"));
        }
     }
}
