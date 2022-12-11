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
            Menu menu = new Menu();
            MenuContent menuCont = new MenuContent();

            message.SignIn();
            menu.Menus();
            menuCont.Menu1();
            menu.Menus();
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

    class MenuContent
    {
        private int productCode;
        private string productName;
        private double productPrice;
        private int productQuantity;
        public void Menu1()
        {
            bool codeRun1 = true;
            while (codeRun1 == true)
            {
                try
                {
                    Console.Write("Please select a menu: ");
                    int input = Convert.ToInt32(Console.ReadLine());

                    if(input <= 9 && input > 0)
                    {
                        switch (input)
                        {
                            case 1:
                                Console.Write("Please input the product code: ");
                                productCode = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Please input the product name: ");
                                productName = Console.ReadLine();
                                Console.Write("Please input the product price: ");
                                productPrice = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Please input the product quantity: ");
                                productQuantity = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("This is case 2.");
                                break;
                            case 3:
                                Console.WriteLine("This is case 3.");
                                break;
                            case 4:
                                Console.WriteLine("This is case 4.");
                                break;
                            case 5:
                                Console.WriteLine("This is case 5.");
                                break;
                            case 6:
                                Console.WriteLine("This is case 6.");
                                break;
                            case 7:
                                Console.WriteLine("This is case 7.");
                                break;
                            case 8:
                                Console.WriteLine("This is case 8.");
                                break;
                            case 9:
                                Console.WriteLine("You've log out.");
                                break;
                        }
                        codeRun1 = false;
                    }
                    else
                        Console.WriteLine("Not in range. Options available ranging 1 - 9 only.\nTry again.\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid! Use integer/number only.\nPlease try again.\n");
                }
            }
        }
    }
}