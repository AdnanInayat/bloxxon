using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<tUser> Users { get; set; }
        public DbSet<tCustomer> Customers { get; set; }
        public DbSet<tInvoice> Invoices { get; set; }
        
    }
}
