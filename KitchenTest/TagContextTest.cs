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
        public void CreateTag()
        {
            using var context = GetContext();
            var tagContext = new TagContext(context);
            var tag = new Tag("Vegan");

            tagContext.Create(tag);
            Assert.Single(context.Tags);
        }

        [Fact]
        public void ReadTag()
        {
            using var context = GetContext();
            var tag = new Tag("Spicy");
            context.Tags.Add(tag);
            context.SaveChanges();

            var tagContext = new TagContext(context);
            var result = tagContext.Read(tag.Id);

            Assert.Equal("Spicy", result.Name);
        }

        [Fact]
        public void UpdateTag()
        {
            using var context = GetContext();
            var tag = new Tag("OldName");
            context.Tags.Add(tag);
            context.SaveChanges();

            var tagContext = new TagContext(context);
            tag.Name = "NewName";
            tagContext.Update(tag);

            var updated = context.Tags.First();
            Assert.Equal("NewName", updated.Name);
        }

        [Fact]
        public void DeleteTag()
        {
            using var context = GetContext();
            var tag = new Tag("Temporary");
            context.Tags.Add(tag);
            context.SaveChanges();

            var tagContext = new TagContext(context);
            tagContext.Delete(tag.Id);

            Assert.Empty(context.Tags);
        }
    }
}
