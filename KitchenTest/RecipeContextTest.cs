using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Linq;

namespace KitchenTest
{
    public class RecipeContextTest
    {
        private KitchenDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<KitchenDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new KitchenDbContext(options);
        }

        [Fact]
        public void Create_Recipe_Works()
        {
            using var context = GetContext();
            var recipeContext = new RecipeContext(context);
            var category = new Category("Main");
            context.Categories.Add(category);
            context.SaveChanges();

            var recipe = new Recipe("Pasta", "Boil pasta", 15, 2, category.Id);
            recipeContext.Create(recipe);

            Assert.Single(context.Recipes);
        }

        [Fact]
        public void Read_Recipe_ReturnsCorrectRecipe()
        {
            using var context = GetContext();
            var category = new Category("Test");
            context.Categories.Add(category);
            var recipe = new Recipe("Salad", "Mix", 5, 1, category.Id);
            context.Recipes.Add(recipe);
            context.SaveChanges();

            var recipeContext = new RecipeContext(context);
            var result = recipeContext.Read(recipe.Id);

            Assert.Equal("Salad", result.Title);
        }
    }
}
