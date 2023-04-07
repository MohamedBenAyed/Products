using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

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
                //var connectionString = @"Data Source=DESKTOP-K63E791;Database=SiNSTTest;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true;";
                var connectionString = @"data source=41.226.29.98;initial catalog=SiNST;user id=se;password=se;multipleactiveresultsets=True;";

                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("SiNst.Context"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        //public virtual DbSet<User> User { get; set; }
        
    }
}
