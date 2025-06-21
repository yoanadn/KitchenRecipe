using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;

namespace KitchenTest
{
    public class TagContextTest
    {
        private KitchenDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<KitchenDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new KitchenDbContext(options);
        }

        [Fact]
        public void Create_Tag_AddsCorrectly()
        {
            using var context = GetContext();
            var tagContext = new TagContext(context);
            var tag = new Tag("Vegan");

            tagContext.Create(tag);
            Assert.Single(context.Tags);
        }

        [Fact]
        public void Read_Tag_ReturnsCorrectTag()
        {
            using var context = GetContext();
            var tag = new Tag("Spicy");
            context.Tags.Add(tag);
            context.SaveChanges();

            var tagContext = new TagContext(context);
            var result = tagContext.Read(tag.Id);

            Assert.Equal("Spicy", result.Name);
        }
    }
}
