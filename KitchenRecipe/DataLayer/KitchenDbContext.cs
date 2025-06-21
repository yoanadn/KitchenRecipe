using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class KitchenDbContext : DbContext
    {
        public static KitchenDbContext dbContext;

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public KitchenDbContext(DbContextOptions options)
            : base(options) { }

        public KitchenDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=127.0.0.1;Database=KitchenDb;Uid=root;Pwd=root");
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
