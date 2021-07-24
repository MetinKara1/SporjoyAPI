using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ProductConfiguration // : IEntityTypeConfiguration<Product>
    {
        //public void Configure(ModelBuilder modelBuilder) // EntityTypeBuilder<Product>
        //{

        //    modelBuilder.Entity<OrderDetail>()
        //.HasKey(od => new { od.OrderId, od.ProductId });
        //    modelBuilder.Entity<OrderDetail>()
        //        .HasOne(od => od.Product)
        //        .WithMany(p => p.OrderDetail)
        //        .HasForeignKey(p => p.ProductId);
        //    modelBuilder.Entity<OrderDetail>()
        //        .HasOne(od => od.Order)
        //        .WithMany(o => o.OrderDetail)
        //        .HasForeignKey(o => o.OrderId);
        //    //builder
        //    //    .HasKey(a => a.Id);

        //    //builder
        //    //    .Property(m => m.Id)
        //    //    .UseIdentityColumn();

        //    //builder
        //    //    .Property(m => m.Name)
        //    //    .IsRequired()
        //    //    .HasMaxLength(50);

        //    //builder
        //    //    .ToTable("Artists");

        //    //builder
        //    //    .HasKey(m => m.Id);

        //    //builder
        //    //    .Property(m => m.Id)
        //    //    .UseIdentityColumn();

        //    //builder
        //    //    .Property(m => m.Name)
        //    //    .IsRequired()
        //    //    .HasMaxLength(50);

        //    //builder
        //    //    .HasOne(m => m.Artist)
        //    //    .WithMany(a => a.Musics)
        //    //    .HasForeignKey(m => m.ArtistId);

        //    //builder
        //    //    .ToTable("Musics");
        //}
    }
}
