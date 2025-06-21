using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using System;

namespace KitchenTest
{
    public class IngredientContextTest
    {
        private KitchenDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<KitchenDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new KitchenDbContext(options);
        }

        [Fact]
        public void Create_Ingredient_Success()
        {
            using var context = GetContext();
            var ingredientContext = new IngredientContext(context);
            var ingredient = new Ingredient("Flour", "2 cups", 1);

            ingredientContext.Create(ingredient);
            Assert.Single(context.Ingredients);
        }

        [Fact]
        public void Read_Ingredient_Success()
        {
            using var context = GetContext();
            var ingredient = new Ingredient("Salt", "1 tsp", 1);
            context.Ingredients.Add(ingredient);
            context.SaveChanges();

            var ingredientContext = new IngredientContext(context);
            var result = ingredientContext.Read(ingredient.Id);

            Assert.Equal("Salt", result.Name);
        }

        [Fact]
        public void Delete_Ingredient_RemovesSuccessfully()
        {
            using var context = GetContext();
            var ingredient = new Ingredient("Sugar", "3 tbsp", 1);
            context.Ingredients.Add(ingredient);
            context.SaveChanges();

            var ingredientContext = new IngredientContext(context);
            ingredientContext.Delete(ingredient.Id);

            Assert.Empty(context.Ingredients);
        }
    }
}
