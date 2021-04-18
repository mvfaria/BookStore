using BookStore.Core.Calculator;
using BookStore.Core.Domain;
using System;
using System.Collections.Generic;

namespace BookStore.App
{
    class Program
    {
        private const decimal GST = 0.1m;

        static void Main(string[] args)
        {
            var order = new Order
            {
                Books = new List<Book>
                {
                    new Book
                    {
                        BookName = "Unsolved Crimes",
                        Category = BookCategory.Crime,
                        TotalCost = 10.99m
                    },
                    new Book
                    {
                        BookName = "A Little Love Story",
                        Category = BookCategory.Romance,
                        TotalCost = 2.40m
                    },
                    new Book
                    {
                        BookName = "Heresy",
                        Category = BookCategory.Fantasy,
                        TotalCost = 6.80m
                    },
                    new Book
                    {
                        BookName = "Jack the Ripper",
                        Category = BookCategory.Crime,
                        TotalCost = 16.00m
                    },
                    new Book
                    {
                        BookName = "The Tolkien Years",
                        Category = BookCategory.Fantasy,
                        TotalCost = 22.90m
                    }
                }
            };

            var calculator = new OrderCalculator(order);
            var crimeDiscount = new CategoryCrimeDiscount();

            Console.WriteLine($"Order Total Cost Before Tax: {calculator.CalculateOrderTotal()}");
            Console.WriteLine($"Order Total Cost Before Tax With Discount: {calculator.CalculateOrderTotal(discount: crimeDiscount)}");
            Console.WriteLine($"Order Total Cost After Tax: {calculator.CalculateOrderTotal(GST)}");
            Console.WriteLine($"Order Total Cost After Tax With Discount: {calculator.CalculateOrderTotal(GST, crimeDiscount)}");
        }
    }
}
