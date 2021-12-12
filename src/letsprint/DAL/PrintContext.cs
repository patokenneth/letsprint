using letsprint.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.DAL
{
    public class PrintContext : DbContext
    {
        public PrintContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().HasKey(k => k.OrderID);
            builder.Entity<OrderDetails>().HasKey(k => k.ItemID);
        }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderdetails { get; set; }
    }
}
