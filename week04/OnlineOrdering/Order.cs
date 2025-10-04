using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products = new List<Product>();
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotalPrice()
        {
            decimal sum = 0m;
            foreach (var p in _products)
            {
                sum += p.GetTotalCost();
            }

            decimal shipping = _customer != null && _customer.LivesInUSA() ? 5m : 35m;
            return sum + shipping;
        }

        public string GetPackingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var p in _products)
            {
                sb.AppendLine($"{p.GetName()} (ID: {p.GetProductId()})");
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Shipping Label:");
            sb.AppendLine(_customer.GetName());
            sb.AppendLine(_customer.GetAddress().GetFullAddress());
            return sb.ToString();
        }
    }
}
