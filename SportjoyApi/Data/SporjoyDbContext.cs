using Core.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporjoy.Data
{
    public class SporjoyDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public SporjoyDbContext(DbContextOptions<SporjoyDbContext> options)
            : base(options)
        { }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder
        //        .ApplyConfiguration(new ProductConfiguration());
        //}
    }
    
}
