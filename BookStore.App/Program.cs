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
            var order = OrderService.GetOrder();
            var calculator = new OrderCalculator(order);
            var crimeDiscount = new CategoryCrimeDiscount();

            Console.WriteLine($"Order Total Cost Before Tax: {calculator.CalculateOrderTotal(discount: crimeDiscount).ToString("C")}");
            Console.WriteLine($"Order Total Cost After Tax: {calculator.CalculateOrderTotal(GST, crimeDiscount).ToString("C")}");
        }
    }
}
