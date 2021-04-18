using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookStore.Core.Calculator
{
    public class OrderCalculatorTest
    {
        [Fact]
        public void ShouldReturnOrderTotal()
        {
            // Arrange
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
                    }
                }
            };

            var calculator = new OrderCalculator(order);

            // Act
            var total = calculator.CalculateOrderTotal();

            // Assert
            Assert.Equal(order.Books.Sum(b => b.TotalCost), total);
        }
    }
}
