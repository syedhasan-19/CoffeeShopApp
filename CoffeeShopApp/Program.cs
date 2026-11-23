using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApp
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    public class CashPayment : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine("Paid $" + amount + " in cash.");
        }
    }

    public class Menu
    {
        public double CoffeePrice { get; set; } = 3.50;
        public double SandwichPrice { get; set; } = 6.00;
    }

    public class CoffeeShop
    {
        public Menu ShopMenu = new Menu();
        private IPaymentProcessor _paymentProcessor;

        public CoffeeShop(IPaymentProcessor processor)
        {
            _paymentProcessor = processor;
        }

        public void PlaceOrder(bool wantsCoffee, bool wantsSandwich)
        {
            double total = wantsCoffee ? ShopMenu.CoffeePrice : 0;
            if (wantsSandwich) total += ShopMenu.SandwichPrice;

            Console.WriteLine("Order Total: $" + total);
            _paymentProcessor.ProcessPayment(total);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor payment = new CashPayment();
            CoffeeShop shop = new CoffeeShop(payment);

            shop.PlaceOrder(true, true);
            Console.ReadLine();
        }
    }
}
