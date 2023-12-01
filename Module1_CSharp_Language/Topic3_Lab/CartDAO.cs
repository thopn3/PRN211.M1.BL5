using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Topic3_Lab
{
    internal class CartDAO
    {
        Cart cart;
        Regex reg;
        public CartDAO()
        {
            cart = new Cart(1, 0.0, DateTime.Now);
        }

        public bool CheckExistProduct(string productId)
        {
            if(cart.products.Count > 0) 
            {
                if(cart.products.Where(p=>p.Key.Id == productId).Count() > 0) 
                    return true;
                else 
                    return false;
            }
            else
            {
                return false;
            }
        }

        public void CalculateTotalPrice()
        {
            if(cart.products.Count > 0)
            {
                cart.Total = 0;
                foreach(var item in cart.products)
                {
                    cart.Total += item.Key.Price * item.Value;
                }
            }
        }
        public void UpdateCart()
        {
            if (cart.products.Count > 0)
            {
                string productId;
                int newQuantity;
                Console.Write("\nEnter ProductID to update: ");
                productId = Console.ReadLine();
                var productUpdate = cart.products.Where(kvp => kvp.Key.Id == productId).FirstOrDefault().Key;
                if (productUpdate != null)
                {
                    Console.Write("Enter new Quantity: ");
                    while (!int.TryParse(Console.ReadLine(), out newQuantity) || newQuantity < 0)
                    {
                        Console.Write("Invalid Quantity! Try again: ");
                    }
                    cart.products[productUpdate] = newQuantity;
                    CalculateTotalPrice();
                    Console.WriteLine("Update success.\n");
                }
                else
                {
                    Console.WriteLine("This product not exist!");
                }
            }
            else
            {
                Console.WriteLine("\n\tCart is empty!\n");
            }
        }

        public void RemoveProductInCart()
        {
            if(cart.products.Count > 0)
            {
                string productId;
                Console.Write("\nEnter ProductId to remove: ");
                productId = Console.ReadLine();
                var productRemove = cart.products.Where(kvp => kvp.Key.Id == productId).FirstOrDefault().Key;
                if (productRemove != null)
                {
                    cart.products.Remove(productRemove);
                    CalculateTotalPrice();
                    Console.WriteLine("Remove success.\n");
                }
                else
                {
                    Console.WriteLine("This product not exist!");
                }
            }
            else
            {
                Console.WriteLine("\n\tCart is empty!\n");
            }
        }

        public void AddToCart()
        {
            string productId;
            string productName;
            double price;
            int quantity = 0;

            int numberOfProducts = 0;
            Console.Write("\nEnter number of products: ");
            while(!int.TryParse(Console.ReadLine(), out numberOfProducts) || numberOfProducts <= 0)
            {
                Console.Write("Number of product must be greater than or equal to zero!\nTry again: ");
            }

            for(int i = 0; i < numberOfProducts; i++)
            {
                Console.WriteLine("Product #" + (i + 1) + ":");
                Console.Write("Enter ProductID: ");
                while (true)
                {
                    string pattern = @"^(P)\d{4}$";
                    reg = new Regex(pattern);
                    productId = Console.ReadLine();
                    if (!reg.IsMatch(productId))
                    {
                        Console.Write("Invalid ProductID!\nRe-Enter ProductID: ");
                    }
                    else
                    {
                        if (CheckExistProduct(productId))
                        {
                            Console.Write("This product is exist!\nTry again: ");
                        }
                        else
                            break;
                    }
                }

                Console.Write("Enter Product name: ");
                productName = Console.ReadLine();

                Console.Write("Enter Price: ");
                while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                {
                    Console.Write("Invalid Price!\nRe-Enter Price: ");
                }

                Console.Write("Enter Quantity: ");
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.Write("Invalid Quantity!\nRe-Enter Quantity: ");
                }

                // Add product to ProductList in cart
                Product newProduct = new Product(productId, productName, price);
                cart.products.Add(newProduct, quantity);
                // Update TotalPrice:
                CalculateTotalPrice();
                Console.WriteLine();
            }
        }

        public void DisplayCart()
        {
            Console.WriteLine("\n--- Cart Information ---");
            if(cart.products.Count > 0)
            {
                Console.WriteLine("CartId: " + cart.CartId);
                Console.WriteLine("Create at: " + cart.CreateAt);
                Console.WriteLine("Products in Cart:");
                Console.WriteLine("Id\t\tName\t\t\tPrice\t\tQuantity\tTotal");
                foreach(var item in cart.products)
                {
                    Console.WriteLine($"{item.Key.Id}\t\t{item.Key.Name}\t\t\t{item.Key.Price}\t\t{item.Value}\t\t{item.Key.Price*item.Value}");
                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Total Price: " + cart.Total);
                Console.WriteLine("-----------------------------------\n");
            }
            else
            {
                Console.WriteLine("\n\tCart is empty!\n");
            }
        }
    }
}
