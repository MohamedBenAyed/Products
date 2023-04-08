using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PRODUCT.Entities;

namespace PRODUCT.Context
{
    public partial class ProductDBContext  : DbContext
    {
        public ProductDBContext()
        {

        }
        public ProductDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Data Source=localhost;Database=ProductDB;Integrated Security=true;TrustServerCertificate=True;";

                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("PRODUCT.Context"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }

        public virtual DbSet<Product> Product { get; set; }
        
    }
}
