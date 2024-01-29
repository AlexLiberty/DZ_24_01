using DZ_24_01;
using DZ_24_01.Migrations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

//string connectionString = "";

//GetConnectionString();

//void GetConnectionString()
//{
//    try
//    {
//        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
//        IConfiguration configuration = builder.Build();
//        connectionString = configuration.GetConnectionString("DefaultConnection");
//    }
//    catch (Exception ex) 
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//}

OrderService orderService = new OrderService();
orderService.EnsurePopulated();
AddOrders();
//GetOrder();

void GetOrder()
{
    var orderId = 1;
    var currentOrder=orderService.GetOrder(orderId);
    if (currentOrder != null)
    {
        Console.WriteLine(currentOrder);
    }
}

void AddOrders()
{
    Order order = new Order
    {
        Address = "Odessa, Dereb 15, 44",
        Fio = "Mukola Pupkin"
    };

    var currePhone = orderService.GetProduct(1);
    var curreTab = orderService.GetProduct(2);

    if (currePhone != null && curreTab != null)
    {
        order.OrderLines.Add(new OrderLine
        {
            ProductId = currePhone.Id,
            Quantity = 2
        });

        order.OrderLines.Add(new OrderLine
        {
            ProductId = curreTab.Id,
            Quantity = 1
        });

        orderService.AddOrder(order);
    }
    else
    {
        Console.WriteLine("Error: Product not found");
    }
}