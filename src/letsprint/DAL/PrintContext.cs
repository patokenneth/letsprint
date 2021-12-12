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


        public DbSet<Order> orders { get; set; }
    }
}
