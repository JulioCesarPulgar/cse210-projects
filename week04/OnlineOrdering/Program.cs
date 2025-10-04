using System;
using OnlineOrdering;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Order 1 - customer in the USA
            var address1 = new Address("123 Main St", "Anytown", "CA", "USA");
            var customer1 = new Customer("John Doe", address1);

            var order1 = new Order(customer1);
            order1.AddProduct(new Product("Widget", "W123", 3.50m, 5));
            order1.AddProduct(new Product("Gadget", "G456", 12.99m, 2));

            Console.WriteLine("--- Order 1 ---");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total: {order1.CalculateTotalPrice():C}");
            Console.WriteLine();

            // Order 2 - international customer
            var address2 = new Address("456 Market St", "Toronto", "ON", "Canada");
            var customer2 = new Customer("Jane Smith", address2);

            var order2 = new Order(customer2);
            order2.AddProduct(new Product("Book", "B789", 9.99m, 3));
            order2.AddProduct(new Product("Pen Set", "P012", 4.25m, 4));
            order2.AddProduct(new Product("Sticky Notes", "S345", 2.50m, 2));

            Console.WriteLine("--- Order 2 ---");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total: {order2.CalculateTotalPrice():C}");
        }
    }
}