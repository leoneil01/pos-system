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

            message.SignIn();
            menu.Menus();

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
            Console.Write("Please select a menu: ");
            string input = Console.ReadLine();
        }
    }
}