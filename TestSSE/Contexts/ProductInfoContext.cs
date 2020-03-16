using System;
using Microsoft.EntityFrameworkCore;
using TestSSE.Entities;

namespace TestSSE.Contexts
{
    public class ProductInfo : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
