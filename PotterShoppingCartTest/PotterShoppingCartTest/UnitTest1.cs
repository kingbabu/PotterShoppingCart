using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCartTest
{
    [TestClass]
    public class UnitTest1
    {
        //1. 一到五集的哈利波特，每一本都是賣100元
        //2. 如果你從這個系列買了兩本不同的書，則會有5%的折扣
        //3. 如果你買了三本不同的書，則會有10%的折扣
        //4. 如果是四本不同的書，則會有20%的折扣
        //5. 如果你一次買了整套一到五集，恭喜你將享有25%的折扣
        //6. 需要留意的是，如果你買了四本書，其中三本不同，第四本則是重複的，
        //   那麼那三本將享有10%的折扣，但重複的那一本，則仍須100元。


        [TestMethod]
        public void Tset_Add_An_Episode_1_To_Shoppingcart_And_Price_Should_Be_100()
        {
            var shoppingcart = new HarryPotterShoppingCart() { Episode_1_Count = 1 };
            var expected = 100;
            var actual = GetPrice(shoppingcart);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tset_Add_An_Episode_1_And_An_Episode_2_To_Shoppingcart_And_Price_Should_Be_190()
        {
            var shoppingcart = new HarryPotterShoppingCart() { Episode_1_Count = 1, Episode_2_Count = 1 };
            var expected = 190;
            var actual = GetPrice(shoppingcart);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tset_Add_An_Episode_1_To_3_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_270()
        {
            var shoppingcart = new HarryPotterShoppingCart() { Episode_1_Count = 1, Episode_2_Count = 1 , Episode_3_Count = 1};
            var expected = 270;
            var actual = GetPrice(shoppingcart);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tset_Add_Episode_1_To_4_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_320()
        {
            var shoppingcart = new HarryPotterShoppingCart() { Episode_1_Count = 1, Episode_2_Count = 1, Episode_3_Count = 1, Episode_4_Count = 1 };
            var expected = 320;
            var actual = GetPrice(shoppingcart);

            Assert.AreEqual(expected, actual);
        }

        private double GetPrice(HarryPotterShoppingCart shoppingcart)
        {
            double result = 0;
            if (shoppingcart.Episode_1_Count == 1) result = 100;
            if (shoppingcart.Episode_1_Count == 1 && shoppingcart.Episode_2_Count == 1) result = 100 * 2 * 0.95;
            if (shoppingcart.Episode_1_Count == 1 && shoppingcart.Episode_2_Count == 1 && shoppingcart.Episode_3_Count == 1) result = 100 * 3 * 0.9;
            if (shoppingcart.Episode_1_Count == 1 && shoppingcart.Episode_2_Count == 1 && shoppingcart.Episode_3_Count == 1 && shoppingcart.Episode_4_Count == 1) result = 100 * 4 * 0.8;
            
            return result;
        }

        private class HarryPotterShoppingCart
        {
            public int Episode_1_Count { get; set; } = 0;
            public int Episode_2_Count { get; set; } = 0;
            public int Episode_3_Count { get; set; } = 0;
            public int Episode_4_Count { get; set; } = 0;
            public int Episode_5_Count { get; set; } = 0;
        }
    }
}