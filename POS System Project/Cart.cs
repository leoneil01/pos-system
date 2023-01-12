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
        public DateTime DateCreated { get; set; }
    }

    class CartRepository : SignInMessage
    {
        ProductRepository productRepo = new ProductRepository();

        private List<Cart> cartItems;
        public CartRepository()
        {
            cartItems = new List<Cart>();
        }
        public void ItemToCart(Product product)
        {
            Console.Write("Please input the quantity that you want to add: ");
            int qty = Convert.ToInt32(Console.ReadLine());
            if (product.ProductQuantity < qty)
            {
                Console.WriteLine("Product quantity must not exceed to the current product quantity.");
            }
            else
            {
                product.ProductQuantity -= qty;
                foreach (Cart cart in cartItems)
                {
                    if (cart.ProductCode == product.ProductCode)
                    {
                        cart.ProductQuantity += qty;
                        Message4();
                        return;
                    }
                }
                cartItems.Add(new Cart()
                {
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = qty,
                    DateCreated = DateTime.Now
                });
                Message4();
            }
        }
        public void RemoveItemInCart()
        {
            Console.Write("Please select the product that you want to remove in the cart (Product Code): ");
            string input = Console.ReadLine();
            foreach (Cart cart in cartItems)
            {
                if(cart.ProductCode == input)
                {
                    cartItems.Remove(cart);
                    cart.ProductQuantity += cart.ProductQuantity;
                    Console.WriteLine("Product has been successfully removed in the cart.");
                    return;
                }
            }
            Console.WriteLine("Product Code does not exist in the cart.");
        }
        public void DisplayAllItemsInCart()
        {
            foreach(var cart in cartItems)
            {
                Console.WriteLine("---ITEMS IN CART---");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Code: {0}", cart.ProductCode);
                Console.WriteLine("Name: {0}", cart.ProductName);
                Console.WriteLine("Price: Php {0:n2}", cart.ProductPrice);
                Console.WriteLine("Quantity: {0:n0}", cart.ProductQuantity);
                Console.WriteLine("Date Created: {0}", cart.DateCreated);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
            }
        }
        public void CheckOut()
        {
            double totalAmount = 0;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("---CHECKOUT RECEIPT---");
            Console.WriteLine("----------------------------------------");

            foreach (Cart cart in cartItems)
            {
                Console.WriteLine("Code: {0}", cart.ProductCode);
                Console.WriteLine("Name: {0}", cart.ProductName);
                Console.WriteLine("Price: Php {0:n2}", cart.ProductPrice);
                Console.WriteLine("Quantity: {0:n0}", cart.ProductQuantity);
                Console.WriteLine("Date Created: {0}", cart.DateCreated);
                totalAmount += cart.ProductPrice * cart.ProductQuantity;
                Console.WriteLine("----------------------------------------");
            }

            Console.WriteLine("Total Amount: Php {0:n2}", totalAmount);
            Console.WriteLine("----------------------------------------");
        }
    }
}
