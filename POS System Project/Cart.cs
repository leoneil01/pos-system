using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System_Project
{
    internal class Cart
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateCreated { get { return DateTime.Now; } }
    }

    class CartRepository : SignInMessage
    {
        private List<Cart> cartItems = new List<Cart>();
        public void AddItemToCart()
        {
            Cart cart = new Cart();
            Console.Write("Please select a product code: ");
            cart.ProductCode = Console.ReadLine();
            Console.Write("Please input the quantity that you want to add: ");
            cart.ProductQuantity = Convert.ToInt32(Console.ReadLine());
            cartItems.Add(cart);
            Console.WriteLine("Product has been successfully added to cart.");
        }
        public void RemoveItemInCart()
        {
            foreach(Cart cart in cartItems)
            {
                Console.Write("Please select the product that you want to remove in the cart (Product Code): ");
                string input = Console.ReadLine();
                if(cart.ProductCode == input)
                {
                    cartItems.Remove(cart);
                    Console.WriteLine("Product has been successfully removed in the cart.");
                    break;
                }
                Message2();
                break;
            }
        }
        public void DisplayAllItemsInCart()
        {
            foreach(Cart cart in cartItems)
            {
                Console.WriteLine("---ITEMS IN CART---");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Code: {0}", cart.ProductCode);
                Console.WriteLine("Name: {0}", cart.ProductName);
                Console.WriteLine("Price: Php {0:F2}", cart.ProductPrice);
                Console.WriteLine("Quantity: {0}", cart.ProductQuantity);
                Console.WriteLine("Date Created: {0}", cart.DateCreated);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
            }
        }
        public void CheckOut()
        {

        }
    }
}
