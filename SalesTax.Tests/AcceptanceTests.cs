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
            var itemFactory = new ItemFactory();
            var shoppingBasket = new List<BasketItem>
                                     {
                                         new BasketItem
                                             {
                                                 Item = itemFactory.ImportTaxExemptItem("imported box of chocolates", 10.00m),
                                                 Quantity = 1
                                             },
                                         new BasketItem
                                             {
                                                 Item = itemFactory.ImportTaxableItem("imported bottle of perfume", 47.50m),
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
       
        [Test]
        public void Satisfy_input_3()
        {
            var itemFactory = new ItemFactory();
            var shoppingBasket = new List<BasketItem>
                                     {
                                         new BasketItem
                                             {
                                                 Item = itemFactory.ImportTaxableItem("imported bottle of perfume", 27.99m),
                                                 Quantity = 1
                                             },
                                             new BasketItem
                                             {
                                                 Item = itemFactory.CreateTaxableItem("bottle of perfume", 18.99m),
                                                 Quantity = 1
                                             },

                                             new BasketItem
                                             {
                                                 Item = itemFactory.CreateTaxExemptItem("packet of headache pills", 9.75m),
                                                 Quantity = 1
                                             },
                                                                                          new BasketItem
                                             {
                                                 Item = itemFactory.ImportTaxExemptItem("imported box of chocolates", 11.25m),
                                                 Quantity = 1
                                             }


                                     };
            var display = new Receipt();
            var checkout = new CheckOut(display);
            checkout.CalculateTotal(shoppingBasket);

            var output = checkout.DisplayReceipt();
            Assert.That(output,
                        Is.EqualTo(
                            "1 imported bottle of perfume: 32.19 1 bottle of perfume: 20.89 1 packet of headache pills: 9.75 1 imported box of chocolates: 11.85 Sales Taxes: 6.70 Total: 74.68"));
        }

    }
}