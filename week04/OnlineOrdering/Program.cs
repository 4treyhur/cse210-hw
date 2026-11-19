using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-100", 15.50m, 2));
        order1.AddProduct(new Product("USB Keyboard", "KB-200", 29.99m, 1));
        order1.AddProduct(new Product("Laptop Stand", "LS-300", 24.00m, 1));

        Address address2 = new Address("Av. Juarez 45, Col. Centro", "Pachuca", "Hidalgo", "Mexico");
        Customer customer2 = new Customer("Maria Lopez", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Water Bottle", "WB-050", 12.00m, 3));
        order2.AddProduct(new Product("Backpack", "BP-400", 45.25m, 1));

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();
    }
}
