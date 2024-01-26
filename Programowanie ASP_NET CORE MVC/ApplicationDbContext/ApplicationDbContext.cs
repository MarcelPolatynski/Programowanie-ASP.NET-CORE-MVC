using Microsoft.EntityFrameworkCore;
using Programowanie_ASP_NET_CORE_MVC.Models;
using System;

namespace Programowanie_ASP_NET_CORE_MVC.DbServices
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ApplicationDbContext;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
