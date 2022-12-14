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
        public string LinkInput { get; set; }
        public DateTime DateCreated { get { return DateTime.Now; } }
    }

    class ProductRepository : SignInMessage
    {
        private List<Product> products = new List<Product>();
        private List<Product> inputs = new List<Product>();
        public void AddProduct()
        {
            var product = new Product();
            var input = new Product();
            Console.Write("Please input the product code: ");
            product.ProductCode = Console.ReadLine();
            input.LinkInput = product.ProductCode;
            Console.Write("Please input the product name: ");
            product.ProductName = Console.ReadLine();
            Console.Write("Please input the product price: ");
            product.ProductPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please input the product quantity: ");
            product.ProductQuantity = Convert.ToInt32(Console.ReadLine());
            products.Add(product);
            inputs.Add(input);
            Console.WriteLine("Product has been successfully created.");
        }
        public void UpdateProduct()
        {
            foreach (var product in products)
            {
                Console.Write("Please select the product that you want to update (Product Code): ");
                if (product.ProductCode == Console.ReadLine())
                {
                    Console.Write("Please input the updated product name: ");
                    product.ProductName = Console.ReadLine();
                    Console.Write("Please input the updated product price: ");
                    product.ProductPrice = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Plese input the updated product quantity: ");
                    product.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Product has been successfully updated.");
                    break;
                }
                Message2();
                break;
            }
        }
        public void DeleteProduct()
        {
            foreach (var product in products)
            {
                var input = new Product();
                Console.Write("Please select the product that you want to delete (Product Code): ");
                product.ProductCode = Console.ReadLine();
                if (input.LinkInput == product.ProductCode)
                {
                    products.Remove(product);
                    Console.WriteLine("Product has been successfully deleted.");
                    break;
                }
                Message2();
                break;
            }
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
