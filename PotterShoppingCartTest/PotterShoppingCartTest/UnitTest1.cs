using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCartTest
{
    [TestClass]
    public class UnitTest1
    {
        private static Dictionary<double, double> _discounts = new Dictionary<double, double>()
        {
            { 1, 1},
            { 2, 0.95},
            { 3, 0.9},
            { 4, 0.8},
            { 5, 0.75},
        };

        //1. 一到五集的哈利波特，每一本都是賣100元
        //2. 如果你從這個系列買了兩本不同的書，則會有5%的折扣
        //3. 如果你買了三本不同的書，則會有10%的折扣
        //4. 如果是四本不同的書，則會有20%的折扣
        //5. 如果你一次買了整套一到五集，恭喜你將享有25%的折扣
        //6. 需要留意的是，如果你買了四本書，其中三本不同，第四本則是重複的，
        //   那麼那三本將享有10%的折扣，但重複的那一本，則仍須100元。

        [TestMethod]
        public void Test_Add_An_Episode_1_To_Shoppingcart_And_Price_Should_Be_100()
        {
            var books = new List<HarryPotter>() { new HarryPotter(1) };

            var expected = 100;
            var actual = GetShoppingcartTotalPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Add_Episode_1_To_2_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_190()
        {
            var books = new List<HarryPotter>() {
                new HarryPotter(1),
                new HarryPotter(2)
            };

            var expected = 190;
            var actual = GetShoppingcartTotalPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Add_Episode_1_To_3_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_270()
        {
            var books = new List<HarryPotter>() {
                new HarryPotter(1),
                new HarryPotter(2),
                new HarryPotter(3),
            };

            var expected = 270;
            var actual = GetShoppingcartTotalPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Add_Episode_1_To_4_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_320()
        {
            var books = new List<HarryPotter>() {
                new HarryPotter(1),
                new HarryPotter(2),
                new HarryPotter(3),
                new HarryPotter(4),
            };

            var expected = 320;
            var actual = GetShoppingcartTotalPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Add_Episode_1_To_5_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_375()
        {
            var books = new List<HarryPotter>() {
                new HarryPotter(1),
                new HarryPotter(2),
                new HarryPotter(3),
                new HarryPotter(4),
                new HarryPotter(5),
            };

            var expected = 375;
            var actual = GetShoppingcartTotalPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Add_Episode_1_To_2_One_Of_Each_And_Two_Episode_3_To_Shoppingcart_And_Price_Should_Be_370()
        {
            var books = new List<HarryPotter>()
            {
                new HarryPotter(1),
                new HarryPotter(2),
                new HarryPotter(3),
                new HarryPotter(3),
            };

            var expected = 370;
            var actual = GetShoppingcartTotalPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Add_Episode_2_To_3_Two_Of_Each_And_An_Episode_1_To_Shoppingcart_And_Price_Should_Be_460()
        {
            var books = new List<HarryPotter>() {
                new HarryPotter(1),
                new HarryPotter(2),
                new HarryPotter(2),
                new HarryPotter(3),
                new HarryPotter(3),
            };

            var expected = 460;
            var actual = GetShoppingcartTotalPrice(books);

            Assert.AreEqual(expected, actual);
        }

        public double GetShoppingcartTotalPrice(List<HarryPotter> books)
        {
            var discountCollectionCount = 0;
            double price = 0;
            var skipCount = 0;

            do
            {
                discountCollectionCount = getDiscountCollectionBooksCount(books, skipCount);
                if (discountCollectionCount > 0)
                {
                    price += discountCollectionCount * 100 * _discounts[discountCollectionCount];
                    skipCount++;
                }
            }
            while (discountCollectionCount > 0);

            return price;
        }

        private static int getDiscountCollectionBooksCount(List<HarryPotter> books, int skipCount)
        {
            var collections = books.GroupBy(b => b.EpisodeNo, (key, g) => g.Skip(skipCount).Take(1).FirstOrDefault()).Count(b => b != null);
            return collections;
        }

        public class HarryPotter
        {
            private int _episodeNo;

            public HarryPotter(int episodeNo)
            {
                _episodeNo = episodeNo;
            }

            public int EpisodeNo { get { return _episodeNo; } }
        }
    }
}