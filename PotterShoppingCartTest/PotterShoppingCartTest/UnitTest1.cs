using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCartTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Tset_Add_Episode_1_To_Shoppingcart_Price_Should_Be_100()
        {
            var shoppingcart = new HarryPotterShoppingCart() { Episode_1_Count = 1 };
            var expected = 100;
            var actual = GetPrice(shoppingcart);

            Assert.AreEqual(expected, actual);
        }

        private decimal GetPrice(HarryPotterShoppingCart shoppingcart)
        {
            var result = 0;
            if (shoppingcart.Episode_1_Count == 1) result = 100;

            return result;
        }

        class HarryPotterShoppingCart
        {
            public int Episode_1_Count { get; set; } = 0;
            public int Episode_2_Count { get; set; } = 0;
            public int Episode_3_Count { get; set; } = 0;
            public int Episode_4_Count { get; set; } = 0;
            public int Episode_5_Count { get; set; } = 0;
        }
    }
}
