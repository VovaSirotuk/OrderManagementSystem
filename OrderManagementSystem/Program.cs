using OrderManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Repository.CustomerRep;
using OrderManagementSystem.Service.CustomerSer;
using OrderManagementSystem.Models;
using OrderManagementSystem.Mapping;
using OrderManagementSystem.Service.OrderService;
using OrderManagementSystem.Repository.OrderRep;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//    var orders = new List<Order>
//    {
//        new Order { CustomerId = 1, OrderDate = DateTime.UtcNow, TotalAmount = 150.00m },
//        new Order { CustomerId = 1, OrderDate = DateTime.UtcNow, TotalAmount = 200.50m },
//        new Order { CustomerId = 2, OrderDate = DateTime.UtcNow, TotalAmount = 99.99m },
//        new Order { CustomerId = 3, OrderDate = DateTime.UtcNow, TotalAmount = 150.00m },
//        new Order { CustomerId = 5, OrderDate = DateTime.UtcNow, TotalAmount = 200.50m },
//        new Order { CustomerId = 5, OrderDate = DateTime.UtcNow, TotalAmount = 99.99m }
//    };

//    context.orders.AddRange(orders);
//    context.SaveChanges();

//    // Додавання товарів до замовлень
//    var orderItems = new List<OrderItem>
//    {
//        new OrderItem { OrderId = orders[0].Id, ProductName = "Laptop", Quantity = 1, Price = 150.00m },
//        new OrderItem { OrderId = orders[1].Id, ProductName = "Phone", Quantity = 1, Price = 200.50m },
//        new OrderItem { OrderId = orders[2].Id, ProductName = "Headphones", Quantity = 2, Price = 49.99m }
//    };

//    context.orderItems.AddRange(orderItems);
//    context.SaveChanges();
//    //    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();


//    //        context.customers.AddRange(new List<Customer>
//    //        {
//    //            new Customer { Name = "John Doe", Email = "john@example.com", Phone = "123-456-7890" },
//    //            new Customer { Name = "Jane Smith", Email = "jane@example.com", Phone = "987-654-3210" },
//    //            new Customer { Name = "Alice Johnson", Email = "alice@example.com", Phone = "555-555-5555" },
//    //            new Customer { Name = "John Doe", Email = "john@example.com", Phone = "123-456-7890" },
//    //            new Customer { Name = "Jane Smith", Email = "jane@example.com", Phone = "987-654-3210" },
//    //            new Customer { Name = "Alice Johnson", Email = "alice@example.com", Phone = "555-555-5555" }
//    //        });

//    //        context.SaveChanges();

//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
