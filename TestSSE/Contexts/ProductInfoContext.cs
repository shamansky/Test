using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TestSSE.Entities;

namespace TestSSE.Contexts
{
    public class ProductInfoContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Products.db");
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;");

        public ProductInfoContext(DbContextOptions<ProductInfoContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(new Product()
                {
                    Id = 1,
                    Name = "Lavender heart",
                    Price = "9.25"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Personalised cufflinks",
                    Price = "45.00"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Kids T-shirt",
                    Price = "19.95"
                });
            base.OnModelCreating(modelBuilder);
                
            
        }
        
    }

}
