using System.Collections.Generic;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class AcceptanceTests
    {
        [Test]
        public void Satisfy_input_one()
        {
            //Input 1: 1 book at 12.49 1 music CD at 14.99 1 chocolate bar at 0.85
            //  Output 1: 1 book : 12.49 1 music CD: 16.49 1 chocolate bar: 0.85 Sales Taxes: 1.50 Total: 29.83
            //NOTE: this output has an inconsistency. The space after '1 book' is inconsistent with the rest of the outputs
            //TODO: use factory to create items
            var itemFactory = new ItemFactory();
            var shoppingBasket = new List<BasketItem>
                                     {
                                         new BasketItem {Item= itemFactory.CreateTaxExemptItem("Book",12.49m),Quantity= 1},
                                         new BasketItem {Item= itemFactory.CreateTaxableItem("music cd",14.99m),Quantity= 1},
                                         new BasketItem {Item= itemFactory.CreateTaxExemptItem("chocolate bar",0.85m),Quantity= 1}
                                     };
            var display = new Receipt();
            var checkout = new CheckOut(display);
            checkout.CalculateTotal(shoppingBasket);

            var output = checkout.DisplayReceipt(); 
            Assert.That(output,
                        Is.EqualTo(
                            "1 book: 12.49 1 music cd: 16.49 1 chocolate bar: 0.85 Sales Taxes: 1.50 Total: 29.83"));
        }

        [Test]
        public void Satisfy_input_two()
        {
            
//Input 2: 1 imported box of chocolates at 10.00 1 imported bottle of perfume at 47.50
            var itemFactory = new ItemFactory();
            var shoppingBasket = new List<BasketItem>
                                     {
                                         new BasketItem
                                             {
                                                 Item = itemFactory.CreateTaxExemptItem("imported box of chocolates", 10.00m),
                                                 Quantity = 1
                                             },
                                         new BasketItem
                                             {
                                                 Item = itemFactory.CreateTaxableItem("imported bottle of perfume", 47.50m),
                                                 Quantity = 1
                                             }
                                     };
            var display = new Receipt();
            var checkout = new CheckOut(display);
            checkout.CalculateTotal(shoppingBasket);
    
            var output = checkout.DisplayReceipt(); 
            Assert.That(output,
                        Is.EqualTo(
                            "1 imported box of chocolates: 10.50 1 imported bottle of perfume: 54.65 Sales Taxes: 7.65 Total: 65.15"));
        }
       

    }
}