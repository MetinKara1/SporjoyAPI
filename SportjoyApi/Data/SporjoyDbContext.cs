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
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StaffTrainer> StaffTrainers { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubProperties> ClubProperties { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Branchs> Branchs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }

        public DbSet<Photos> Photos { get; set; }

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
