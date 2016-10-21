﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var books = new List<Book>() { new Book(1) };

            var expected = 100;
            var actual = GetPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tset_Add_An_Episode_1_To_2_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_190()
        {
            var books = new List<Book>() { new Book(1),
                                           new Book(2) };

            var expected = 190;
            var actual = GetPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tset_Add_An_Episode_1_To_3_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_270()
        {
            var books = new List<Book>() { new Book(1),
                                           new Book(2),
                                           new Book(3),};

            var expected = 270;
            var actual = GetPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tset_Add_An_Episode_1_To_4_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_320()
        {
            var books = new List<Book>() { new Book(1),
                                           new Book(2),
                                           new Book(3),
                                           new Book(4),};

            var expected = 320;
            var actual = GetPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tset_Add_An_Episode_1_To_5_One_Of_Each_To_Shoppingcart_And_Price_Should_Be_375()
        {
            var books = new List<Book>() { new Book(1),
                                           new Book(2),
                                           new Book(3),
                                           new Book(4),
                                           new Book(5),};

            var expected = 375;
            var actual = GetPrice(books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tset_Add_An_Episode_1_To_2_One_Of_Each_And_Two_Episode_3_To_Shoppingcart_And_Price_Should_Be_370()
        {
            var books = new List<Book>() { new Book(1),
                                           new Book(2),
                                           new Book(3),
                                           new Book(3),};

            var expected = 370;
            var actual = GetPrice(books);

            Assert.AreEqual(expected, actual);
        }

        private double GetPrice(List<Book> books)
        {
            var groups = books.GroupBy(b => b.EpisodeNo);

            var discountGroups = new List<HarryPotterDiscountCollection>();
            
            while (books.Count > 0)
            {
                var collection = new HarryPotterDiscountCollection();
                foreach (var group in groups)
                {
                    foreach (var book in group.ToList())
                    {
                        collection.Books.Add(book);
                        books.Remove(book);
                        break;
                    }
                }

                discountGroups.Add(collection);
            }
            
            double result = discountGroups.Select(c => c.Price).Sum();
            return result;
        }

        

        class Book
        {
            private int _episodeNo;

            public Book(int episodeNo)
            {
                _episodeNo = episodeNo;
            }
            public int EpisodeNo { get { return _episodeNo; } }
            public double Price { get { return 100; } }
        }

        class HarryPotterDiscountCollection
        {
            public List<Book> Books { get; set; } = new List<Book>();

            public double Price { get { return Books.Count * 100 * getDiscount(Books.Count); } }

            //double Discount { private get { return getOff(Books.Count); } }
        }

        private static double getDiscount(int count)
        {
            double off = 0;

            switch (count)
            {
                case 1:
                    off = 1;
                    break;
                case 2:
                    off = 0.95;
                    break;
                case 3:
                    off = 0.9;
                    break;
                case 4:
                    off = 0.8;
                    break;
                case 5:
                    off = 0.75;
                    break;
                default:
                    break;
            }

            return off;
        }
    }
}