using BookStore.Core.Calculator;
using BookStore.Core.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookStore.Core.Tests.Calculator
{
    public class OrderCalculatorTest
    {
        private readonly Order _order;
        private readonly Mock<IDiscount> _discountMock;
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
                    },
                    new Book
                    {
                        BookName = "Heresy",
                        Category = BookCategory.Fantasy,
                        TotalCost = 6.80m
                    }
                }
            };

            _discountMock = new Mock<IDiscount>();

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

        [Theory]
        [InlineData(0.01)]
        [InlineData(0.025)]
        public void ShouldReturnOrderTotalBeforeTaxWithDiscountApplied(decimal discount)
        {
            Order orderWithDiscountApplied = null;

            _discountMock.Setup(x => x.Apply(It.IsAny<Order>()))
                .Returns((Order order) =>
                {
                    var originalValue = order.Books.First().TotalCost;
                    order.Books.First().TotalCost = originalValue - (originalValue - discount);

                    orderWithDiscountApplied = order;

                    return order;
                });

            var total = _calculator.CalculateOrderTotal(discount: _discountMock.Object);

            _discountMock.Verify(x => x.Apply(It.IsAny<Order>()), Times.Once);

            Assert.NotNull(orderWithDiscountApplied);
            Assert.Equal(orderWithDiscountApplied.Books.Sum(b => b.TotalCost), total);
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.15)]
        public void ShouldReturnOrderTotalAfterTax(decimal tax)
        {
            var orderTotal = _order.Books.Sum(b => b.TotalCost);
            var orderTotalWithTax = orderTotal + (orderTotal * tax);

            var total = _calculator.CalculateOrderTotal(tax);

            Assert.Equal(orderTotalWithTax, total);
        }
    }
}
