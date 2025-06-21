using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;

namespace KitchenTest
{
    public class CategoryContextTest
    {
        private KitchenDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<KitchenDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new KitchenDbContext(options);
        }

        [Fact]
        public void Create_Category_Works()
        {
            using var context = GetContext();
            var categoryContext = new CategoryContext(context);
            var category = new Category("Desserts");

            categoryContext.Create(category);
            Assert.Single(context.Categories);
        }

        [Fact]
        public void Update_Category_ChangesName()
        {
            using var context = GetContext();
            var category = new Category("Old Name");
            context.Categories.Add(category);
            context.SaveChanges();

            var categoryContext = new CategoryContext(context);
            category.Name = "New Name";
            categoryContext.Update(category);

            Assert.Equal("New Name", context.Categories.First().Name);
        }
    }
}
