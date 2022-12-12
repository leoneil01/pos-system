using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System_Project
{
    public class AuthorList
    {
        List<string> AuthorLists = new List<string>();

        public void Author()
        {
            Console.Write("Enter an author: ");
            string input = Console.ReadLine();

            AuthorLists.Add(input);

            Console.Write("Displaying authors: ");
            foreach(string author in AuthorLists)
            {
                Console.WriteLine(author);
            }
        }
    }
}
