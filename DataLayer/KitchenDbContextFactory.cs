using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DataLayer
{
    public class KitchenDbContextFactory : IDesignTimeDbContextFactory<KitchenDbContext>
    {
        public KitchenDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KitchenDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KitchenDb;Trusted_Connection=True;");

            return new KitchenDbContext(optionsBuilder.Options);
        }
    }
}
