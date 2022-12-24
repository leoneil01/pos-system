using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System_Project
{
    internal class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateCreated { get; set; }
    }

    class ProductRepository : SignInMessage
    {
        private List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>();
        }
        public string input { get; set; }
        public void AddProduct()
        {
            if (products.Count == 0) //first check the count if empty or not
            {
                Product1(); //if empty, execute normal iteration
                return;
            }
            Product2(); //if not empty, execute the foreach loop that checks if product code is already used or exist
        }
        public void Product1() //normal iteration
        {
            var product = new Product();
            Console.Write("Please input the product code: ");
            product.ProductCode = Console.ReadLine();
            Console.Write("Please input the product name: ");
            product.ProductName = Console.ReadLine();
            Console.Write("Please input the product price: ");
            product.ProductPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please input the product quantity: ");
            product.ProductQuantity = Convert.ToInt32(Console.ReadLine());
            product.DateCreated = DateTime.Now;
            products.Add(product);
            Console.WriteLine("Product has been successfully created.");
        }
        public void Product2() //checks if product code is already existed
        {
            Console.Write("Please input the product code: ");
            input = Console.ReadLine();
            foreach (var product in products)
            {
                if (product.ProductCode == input)
                {
                    Message3();
                    return;
                }
            }
            Product3(); //if product code is not found, execute this iteration
        }
        public void Product3()
        {
            Product product1 = new Product();
            var product = product1;
            product.ProductCode = input; //takes the input above (Product2) and asign it to product code
            Console.Write("Please input the product name: ");
            product.ProductName = Console.ReadLine();
            Console.Write("Please input the product price: ");
            product.ProductPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please input the product quantity: ");
            product.ProductQuantity = Convert.ToInt32(Console.ReadLine());
            product.DateCreated = DateTime.Now;
            products.Add(product);
            Console.WriteLine("Product has been successfully created.");
        }
        public void UpdateProduct()
        {
            Console.Write("Please select the product that you want to update (Product Code): ");
            input = Console.ReadLine();
            foreach (var product in products)
            {
                if (product.ProductCode == input)
                {
                    Console.Write("Please input the updated product name: ");
                    product.ProductName = Console.ReadLine();
                    Console.Write("Please input the updated product price: ");
                    product.ProductPrice = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Plese input the updated product quantity: ");
                    product.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Product has been successfully updated.");
                    return;
                }
            }
            Message2();
        }
        public void DeleteProduct()
        {
            Console.Write("Please select the product that you want to delete (Product Code): ");
            input = Console.ReadLine();
            foreach (var product in products)
            {
                if (product.ProductCode == input)
                {
                    products.Remove(product);
                    Console.WriteLine("Product has been successfully deleted.");
                    return;
                }
            }
            Message2();
        }
        public void DisplayAllProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine("---LISTS OF PRODUCT---");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Code: {0}", product.ProductCode);
                Console.WriteLine("Name: {0}", product.ProductName);
                Console.WriteLine("Price: Php {0:F2}", product.ProductPrice);
                Console.WriteLine("Quantity: {0}", product.ProductQuantity);
                Console.WriteLine("Date Created: {0}", product.DateCreated);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
