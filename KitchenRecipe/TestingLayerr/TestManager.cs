using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace TestingLayer
{
    [TestFixture]
    public class TestManager
    {

        internal static KitchenDbContext dbContext;

        static TestManager()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("DbForTest");
            dbContext = new KitchenDbContext(builder.Options);
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            dbContext.Dispose();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }


}
