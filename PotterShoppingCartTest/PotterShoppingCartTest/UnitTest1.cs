using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            var shoppingcart = new HarryPotterShoppingCart()
            {
                Episodes_1 = new List<Book>() { new HarryPotterEpisode_1()}
            };
            var expected = 100;
            var actual = GetPrice(shoppingcart);

            Assert.AreEqual(expected, actual);
        }
        
        private double GetPrice(HarryPotterShoppingCart shoppingcart)
        {
            double result = 0;
            if (shoppingcart.Episodes_1.Count > 0) result = shoppingcart.Episodes_1.Select(e => e.Price).Sum();

            return result;
        }

        private class HarryPotterShoppingCart
        {
            public List<Book> Episodes_1 { get; set; }
            public List<Book> Episodes_2 { get; set; }
            public List<Book> Episodes_3 { get; set; }
            public List<Book> Episodes_4 { get; set; }
            public List<Book> Episodes_5 { get; set; }
        }

        class HarryPotterEpisode_1 : Book
        {
            public string Name { get { return "Episode1"; } }

        }
        class HarryPotterEpisode_2 : Book
        {
            public string Name { get { return "Episode2"; } }

        }
        class HarryPotterEpisode_3 : Book
        {
            public string Name { get { return "Episode3"; } }

        }
        class HarryPotterEpisode_4 : Book
        {
            public string Name { get { return "Episode4"; } }

        }
        class HarryPotterEpisode_5 : Book
        {
            public string Name { get { return "Episode5"; } }

        }

        class Book
        {
            //public string Name { get { return "Episode1"; } }
            public double Price { get { return 100; } }
        }
    }
}