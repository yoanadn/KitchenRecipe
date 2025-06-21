using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace KitchenTest
{
    public class TestManager : IDisposable
    {
        internal static KitchenDbContext dbContext;

        static TestManager()
        {
            var options = new DbContextOptionsBuilder<KitchenDbContext>()
                .UseInMemoryDatabase("DbForTest")
                .Options;

            dbContext = new KitchenDbContext(options);
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
