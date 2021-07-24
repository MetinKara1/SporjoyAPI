using Core;
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
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Player> Customers { get; set; }
        public DbSet<User> Users { get; set; }

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
