﻿using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public  class SalesTaxExtensionsTests
    {
        [Test]
        public void One_should_round_to_one()
        {
            const decimal amount = 1m;
            Assert.That(amount.TaxRound(),Is.EqualTo(1.0m));
        }

        [Test]
        public void One_point_05_should_round_to_same()
        {
            const decimal amount = 1.05m;
            Assert.That(amount.TaxRound(), Is.EqualTo(1.05m));
        }

        [Test]
        public void One_point_01_should_round_to_05()
        {
            const decimal amount = 1.01m;
            Assert.That(amount.TaxRound(), Is.EqualTo(1.05m));
        }

        [Test]
        public void One_point_06_should_round_to_10()
        {
            const decimal amount = 1.06m;
            Assert.That(amount.TaxRound(), Is.EqualTo(1.10m));
        }

        [Test]
        public void zero_point_725_should_round_to_zero_point_75()
        {
            const decimal amount = 0.725m;
            Assert.That(amount.TaxRound(), Is.EqualTo(0.75m));
        }
    }
}
