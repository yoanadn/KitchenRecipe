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
        public void CreateRecipe()
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
        public void ReadRecipe()
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

        [Fact]
        public void UpdateRecipe()
        {
            using var context = GetContext();
            var category = new Category("Starter");
            context.Categories.Add(category);
            var recipe = new Recipe("Soup", "Heat", 10, 3, category.Id);
            context.Recipes.Add(recipe);
            context.SaveChanges();

            var recipeContext = new RecipeContext(context);
            recipe.Title = "Hot Soup";
            recipe.PreparationTime = 12;
            recipeContext.Update(recipe);

            var updated = context.Recipes.First();
            Assert.Equal("Hot Soup", updated.Title);
            Assert.Equal(12, updated.PreparationTime);
        }

        [Fact]
        public void DeleteRecipe()
        {
            using var context = GetContext();
            var category = new Category("Temp");
            context.Categories.Add(category);
            var recipe = new Recipe("ToDelete", "Do this", 20, 4, category.Id);
            context.Recipes.Add(recipe);
            context.SaveChanges();

            var recipeContext = new RecipeContext(context);
            recipeContext.Delete(recipe.Id);

            Assert.Empty(context.Recipes);
        }
    }
}
