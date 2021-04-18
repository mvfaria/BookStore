using BookStore.Core.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookStore.Core.Tests.Calculator
{
    public class OrderCalculatorTest
    {
        private readonly Order _order;
        private readonly OrderCalculator _calculator;

        public OrderCalculatorTest()
        {
            _order = new Order
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

            _calculator = new OrderCalculator(_order);
        }

        [Fact]
        public void ShouldReturnOrderTotalBeforeTax()
        {
            var total = _calculator.CalculateOrderTotal();

            Assert.Equal(_order.Books.Sum(b => b.TotalCost), total);
        }

        [Fact]
        public void ShouldThrowExceptionIfOrderIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new OrderCalculator(null));

            Assert.Equal("order", exception.ParamName);
        }

        [Fact]
        public void ShouldReturnOrderTotalAfterTax()
        {
            var tax = 0.1m;

            var total = _calculator.CalculateOrderTotal(tax);

            Assert.Equal(_order.Books.Sum(b => b.TotalCost) * tax, total);
        }
    }
}
