using BlApi;
using BO;

class Program
{
    static void Main()
    {
        IBl bl = Factory.Get();

        var order = bl.Order.CreateOrder();

        while (true)
        {
            Console.WriteLine("\n===== BL MAIN MENU =====");
            Console.WriteLine("1. Add Product To Order");
            Console.WriteLine("2. Show Cart");
            Console.WriteLine("3. Calculate Total");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Product ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Count: ");
                    int count = int.Parse(Console.ReadLine());

                    bl.Order.AddProductToOrder(order, id, count);
                    Console.WriteLine("Added!");
                    break;

                case 2:
                    ShowCart(order);
                    break;

                case 3:
                    bl.Order.CalcTotalPrice(order);
                    Console.WriteLine($"Total: {order.TotalPrice}");
                    break;

                case 4:
                    bl.Order.DoOrder(order);
                    Console.WriteLine("Order completed!");
                    break;

                //case 5:
                //    return;https://chatgpt.com/c/69f9f4d8-ec24-8329-8cd2-32e24a
            }
        }
    }

    static void ShowCart(Order order)
    {
        Console.WriteLine("\n--- CART ---");
        if (order.ProductInOrder == null || order.ProductInOrder.Count == 0)
        {
            Console.WriteLine("Cart is empty");
            return;
        }

        foreach (var p in order.ProductInOrder)
        {
            Console.WriteLine($"{p.ProductId} | {p.ProductName} | Qty: {p.Count} | Final: {p.FinalPrice}");
        }
    }
}