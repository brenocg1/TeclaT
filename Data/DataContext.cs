using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Models;

namespace TeclaT.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<VW_PRODUCTS>()
                .ToView(nameof(VW_PRODUCTS))
                .HasKey(t => t.ID);
        }

        public DbSet<VW_PRODUCTS> VW_PRODUCTS { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
