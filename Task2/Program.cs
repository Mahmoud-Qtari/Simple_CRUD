using Task2.Date;
using Task2.Models;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();


            Product product1 = new Product() { Name = "product1", Price = 10 };
            Product product2 = new Product() { Name = "product2", Price = 10 };

            Order order1 = new Order() { Address = "order1" };
            Order order2 = new Order() { Address = "order2" };

            context.products1.Add(product1);
            context.products1.Add(product2);

            context.Orders1.Add(order1);
            context.Orders1.Add(order2);

            context.SaveChanges();

            //Read
            var AllProducts = context.products1.ToList();
            var AllOrders = context.Orders1.ToList();

            foreach(var p in AllProducts)
            {
                Console.WriteLine(p.Name);
            }
            foreach (var o in AllOrders)
            {
                Console.WriteLine(o.Address);
            }

            //update name of product id=1
            var product = context.products1.FirstOrDefault(p => p.Id==2);
            product.Name = "product2_update";
            context.SaveChanges();

            //update date of order id=2
            var order = context.Orders1.FirstOrDefault(o => o.Id == 2);
            order.CreatedAt = DateTime.Now;
            context.SaveChanges();

            //remove product id=1
            var product_1 = context.products1.FirstOrDefault(p => p.Id == 2);
            context.products1.Remove(product_1);
            context.SaveChanges();

            //romove order id=2
            var order_1 = context.Orders1.FirstOrDefault(o => o.Id == 2);
            context.Orders1.Remove(order_1);
            context.SaveChanges();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
