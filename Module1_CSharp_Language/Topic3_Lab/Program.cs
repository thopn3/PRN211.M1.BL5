using Topic3_Lab;

CartDAO cartDAO = new CartDAO();

while (true)
{
    Console.WriteLine("--- CART MANAGEMENT ---");
    Console.WriteLine("1. Add product to Cart");
    Console.WriteLine("2. Display Cart");
    Console.WriteLine("3. Update Cart");
    Console.WriteLine("4. Remove Product from Cart");
    Console.WriteLine("5. Exit");
    Console.Write("Select a function: ");

    int choice = 0;
    choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            cartDAO.AddToCart(); break;
        case 2:
            cartDAO.DisplayCart(); break;
        case 3:
            cartDAO.UpdateCart(); break;
        case 4:
            cartDAO.RemoveProductInCart(); break;
        case 5:
            Console.WriteLine("Goodbye!\n");
            Environment.Exit(0);
            break;
    }
}
