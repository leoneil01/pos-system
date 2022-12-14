using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System_Project
{
    internal class SignInMessage
    {
        private string userName { get; set; }
        private string password { get; set; }
        public void Message1()
        {
            Console.WriteLine("\nWELCOME TO LEONEIL'S POS SYSTEM");
            Console.WriteLine("---------------------");
        }
        public void Message2()
        {
            Console.WriteLine("Product Code does not exist.");
        }
        public void Message3()
        {
            Console.WriteLine("Product code is alredy exist.");
        }
        public void SignIn()
        {
            Message1();

            while (true)
            {
                Console.WriteLine("Please sign in to access the system.");
                Console.Write("Enter username: ");
                userName = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if (userName == "user" && password == "123")
                    break;
                Console.WriteLine("Invalid username/password. Please try again.\n");
            }
        }
        public void LogOut()
        {
            Console.Write("You've log out.\nPress any key to close this window . . .");
            Console.ReadKey();
        }
    }
}
