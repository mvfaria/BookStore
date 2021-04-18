using BookStore.Core.Domain;
using System.Collections.Generic;

namespace BookStore.App
{
    internal class OrderService
    {
        internal static Order GetOrder()
        {
            return new Order
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
        }
    }
}
