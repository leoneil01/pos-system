using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace POS_System_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            SignInMessage message = new SignInMessage();
            MenuContent menuCont = new MenuContent();

            message.SignIn();
            menuCont.Menu1();
        }
    }

    class SignInMessage
    {
        public void Message()
        {
            Console.WriteLine("\nWELCOME TO LEONEIL'S POS SYSTEM");
            Console.WriteLine("---------------------");
        }

        public void SignIn()
        {
            Message();

            while (true)
            {
                Console.WriteLine("Please sign in to access the system.");
                Console.Write("Enter username: ");
                string userName = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (userName == "user" && password == "123")
                    break;
                Console.WriteLine("Invalid username/password. Please try again.\n");
            }
        }
        public void Message2()
        {
            Console.WriteLine("Product Code does not exist.");
        }
        public void Message3()
        {
            Console.WriteLine("Product code is alredy exist.");
        }
        public void LogOut()
        {
            Console.Write("You've log out.\nPress any key to close this window . . .");
            Console.ReadKey();
        }
    }

    class Menu : SignInMessage
    {
        public void Menus()
        {
            Message();

            Console.WriteLine("1. ADD PRODUCT");
            Console.WriteLine("2. UPDATE PRODUCT");
            Console.WriteLine("3. DELETE PRODUCT");
            Console.WriteLine("4. DISPLAY ALL PRODUCTS");
            Console.WriteLine("5. ADD ITEM TO CART");
            Console.WriteLine("6. REMOVE ITEM TO CART");
            Console.WriteLine("7. DISPLAY ALL ITEMS IN CART");
            Console.WriteLine("8. CHECKOUT");
            Console.WriteLine("9. LOGOUT");
            Console.WriteLine("---------------------");
        }
    }

    class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateCreated { get { return DateTime.Now; } }
    }

    class ProductRepository : SignInMessage
    {
        List<Product> products = new List<Product>();
        public void AddProduct()
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
            products.Add(product);
            Console.WriteLine("Product has been successfully created.");
        }
        public void UpdateProduct()
        {
            foreach(var product in products)
            {
                Console.Write("Please select the product that you want to update (Product Code): ");
                if(product.ProductCode == Console.ReadLine())
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
            foreach(var product in products)
            {
                Console.Write("Please select the product that you want to delete (Product Code): ");
                string input = Console.ReadLine();
                if(product.ProductCode == input)
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
            foreach(var product in products)
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

    class MenuContent : Menu
    {
        ProductRepository productRepo = new ProductRepository();
        CartRepository cartRepo = new CartRepository();

        public void Menu1()
        {
            bool codeRun1 = true;
            while (codeRun1 == true)
            {
                try
                {
                    Menus();
                    Console.Write("Please select a menu: ");
                    int input = Convert.ToInt32(Console.ReadLine());

                    if(input <= 9 && input > 0)
                    {
                        switch (input)
                        {
                            case 1:
                                productRepo.AddProduct();
                                continue;
                            case 2:
                                productRepo.UpdateProduct();
                                continue;
                            case 3:
                                productRepo.DeleteProduct();
                                continue;
                            case 4:
                                productRepo.DisplayAllProducts();
                                continue;
                            case 5:
                                cartRepo.AddItemToCart();
                                continue;
                            case 6:
                                cartRepo.RemoveItemInCart();
                                continue;
                            case 7:
                                cartRepo.DisplayAllItemsInCart();
                                continue;
                            case 8:
                                cartRepo.CheckOut();
                                continue;
                            case 9:
                                LogOut();
                                break;
                        }
                        codeRun1 = false;
                    }
                    else
                        Console.WriteLine("Not in range. Options available ranging 1 - 9 only.\nTry again.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid! Use integer/number only.\nPlease try again.");
                }
            }
        }
    }
}