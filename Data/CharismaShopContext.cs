using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CharismaShop.Model;

namespace CharismaShop.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
               : base(options) { }

        public DbSet<Order> Orders { get; set; }

    }
}