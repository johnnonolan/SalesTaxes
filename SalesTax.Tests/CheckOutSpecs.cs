using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class CheckOutSpecs
    {
        [Test] 
        public void When_purchasing_a_non_taxible_item_it_should_not_alter_price()
        {
            var receiptMock = new Mock<IDisplay>();
            //TODO: this is to be fleshed out 
            //receiptMock.Setup(x => x.Display(It.IsAny<CheckOut>())).Returns("1 book : 1.29 Sales Taxes: 0.00 Total: 0.00").Verifiable();               
            var checkOut = new CheckOut(receiptMock.Object);
            var nonTaxableItem = new BasketItem {Price = 1.29m, Product = "Book", Quantity = 1};
            checkOut.CalculateTotal(new List<BasketItem> { nonTaxableItem });
            Assert.That(checkOut.DisplayReceipt(), Is.EqualTo("1 book : 1.29 Sales Taxes: 0.00 Total: 1.29"));
        }

    }
}
