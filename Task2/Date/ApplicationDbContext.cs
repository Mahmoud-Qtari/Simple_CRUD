using Microsoft.EntityFrameworkCore;
using System;
using Task2.Models;

namespace Task2.Date
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2VPR9IB;Database=ASP9_EF;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<Product> products1 { set; get; }
        public DbSet<Order> Orders1 { set; get; }
    }
}
