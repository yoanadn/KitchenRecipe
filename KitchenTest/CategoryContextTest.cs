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
        public void CreateCategory()
        {
            using var context = GetContext();
            var categoryContext = new CategoryContext(context);
            var category = new Category("Desserts");

            categoryContext.Create(category);
            Assert.Single(context.Categories);
        }

        [Fact]
        public void ReadCategory()
        {
            using var context = GetContext();
            var category = new Category { Name = "Brunch" };
            context.Categories.Add(category);
            context.SaveChanges();

            var categoryContext = new CategoryContext(context);
            var result = categoryContext.Read(category.Id);

            Assert.NotNull(result);
            Assert.Equal("Brunch", result.Name);
        }

        [Fact]
        public void UpdateCategory()
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

        [Fact]
        public void DeleteCategory()
        {
            using var context = GetContext();
            var category = new Category { Name = "Temp" };
            context.Categories.Add(category);
            context.SaveChanges();

            var categoryContext = new CategoryContext(context);
            categoryContext.Delete(category.Id);

            Assert.Empty(context.Categories);
        }
    }
}
