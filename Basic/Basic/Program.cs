using System;
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace BT3
{
    public class Product
    {
        public string Name;
        public int Price;
        public int Quantities;

        public Product(string _Name, int _Price, int _Quantities)
        {
            Name = _Name;
            Price = _Price;
            Quantities = _Quantities;
        }

    }
    public class Bill
    {
        public int Bill_ID;
        public string Customer_Name;
        public DateTime Release_date;

        public List<Product> ProductList = new List<Product>();

        public Bill(int _bill_ID, string _customer_Name, DateTime _release_date)
        {
            Bill_ID = _bill_ID;
            Customer_Name = _customer_Name;
            Release_date = _release_date;
        }
        public int CalculatePrice()
        {
            int total_price = 0;
            foreach (Product p in ProductList)
            {
                total_price += p.Price * p.Quantities;
            }
            return total_price;
        }
        public void addProductList(Product _pd)
        {
            ProductList.Add(_pd);
        }
        //print bill
        public void displayBill()
        {
            Console.WriteLine($"Bill ID: {Bill_ID}, Customer Name: {Customer_Name}, Release date: {Release_date}");

            Console.WriteLine("Product:");
            foreach (var product in ProductList)
            {
                Console.WriteLine($"Product Name: {product.Name}, Price: {product.Price}, Quantities: {product.Quantities}");
            }
            Console.WriteLine("Total price: {0}", CalculatePrice());
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Bill new_bill = new Bill(1, "Cuong", DateTime.Today);
            new_bill.addProductList(new Product("Coca", 10000, 2));
            new_bill.addProductList(new Product("Beer", 10000, 4));
            new_bill.displayBill();
        }
    }
}