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
            menuCont.MainMenu();
        }
    }

    class Menu : SignInMessage
    {
        public void Menus()
        {
            Message1();

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

    class MenuContent : Menu
    {
        ProductRepository productRepo = new ProductRepository();
        CartRepository cartRepo = new CartRepository();
        private int input { get; set; }

        public void MainMenu()
        {
            bool codeRun1 = true;
            while (codeRun1 == true)
            {
                try
                {
                    Menus();
                    Console.Write("Please select a menu: ");
                    input = Convert.ToInt32(Console.ReadLine());

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
                                AddItemToCart();
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
        public void AddItemToCart()
        {
            Console.Write("Please select a product code: ");
            string input = Console.ReadLine();
            Product product = productRepo.GetList(input);
            if (product == null)
            {
                Console.WriteLine("Product code does not exist in the product list.");
                return;
            }
            cartRepo.ItemToCart(product);
        }
    }
}