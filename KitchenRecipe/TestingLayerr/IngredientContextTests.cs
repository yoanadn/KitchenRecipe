using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestingLayer
{

    [TestFixture]
    public class IngredientContextTest
    {
        private IngredientContext ingredientContext;
        private KitchenDbContext dbContext;
        private Recipe testRecipe;
        private Category testCategory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbContext = TestManager.dbContext;
            ingredientContext = new IngredientContext(dbContext);

            testCategory = dbContext.Categories.FirstOrDefault(c => c.Id == 1);
            if (testCategory == null)
            {
                testCategory = new Category("Test Category") { Id = 1 };
                dbContext.Categories.Add(testCategory);
                dbContext.SaveChanges();
            }

            testRecipe = dbContext.Recipes.FirstOrDefault(r => r.Id == 1);
            if (testRecipe == null)
            {
                testRecipe = new Recipe(
                    title: "Test Recipe",
                    instructions: "Test instructions",
                    preparationTime: 30,
                    servings: 4,
                    categoryId: testCategory.Id)
                {
                    Id = 1 
                };
                dbContext.Recipes.Add(testRecipe);
                dbContext.SaveChanges();
            }
        }

        [SetUp]
        public void SetUp()
        {
            dbContext.Ingredients.RemoveRange(dbContext.Ingredients);
            dbContext.SaveChanges();
        }

        [Test]
        public void CreateIngredient()
        {
            var ingredient = new Ingredient("Flour", "200g", testRecipe.Id);
            int initialCount = dbContext.Ingredients.Count();

            ingredientContext.Create(ingredient);

            var created = dbContext.Ingredients.FirstOrDefault(i => i.Name == "Flour");
            Assert.Multiple(() =>
            {
                Assert.That(dbContext.Ingredients.Count(), Is.EqualTo(initialCount + 1));
                Assert.That(created, Is.Not.Null);
                Assert.That(created.Quantity, Is.EqualTo("200g"));
                Assert.That(created.RecipeId, Is.EqualTo(testRecipe.Id));
            });
        }

        [Test]
        public void ReadIngredient()
        {
            var ingredient = new Ingredient("Sugar", "100g", testRecipe.Id);
            ingredientContext.Create(ingredient);

            var result = ingredientContext.Read(ingredient.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Name, Is.EqualTo("Sugar"));
                Assert.That(result.Quantity, Is.EqualTo("100g"));
                Assert.That(result.RecipeId, Is.EqualTo(testRecipe.Id));
            });
        }

        [Test]
        public void UpdateIngredient()
        {
            var ingredient = new Ingredient("Salt", "1 tsp", testRecipe.Id);
            ingredientContext.Create(ingredient);
            var toUpdate = ingredientContext.Read(ingredient.Id);

            toUpdate.Name = "Sea Salt";
            toUpdate.Quantity = "1 tbsp";
            ingredientContext.Update(toUpdate);

            var updated = ingredientContext.Read(ingredient.Id);
            Assert.Multiple(() =>
            {
                Assert.That(updated.Name, Is.EqualTo("Sea Salt"));
                Assert.That(updated.Quantity, Is.EqualTo("1 tbsp"));
            });
        }

        [Test]
        public void DeleteIngredient()
        {
            var ingredient = new Ingredient("Butter", "50g", testRecipe.Id);
            ingredientContext.Create(ingredient);
            int initialCount = dbContext.Ingredients.Count();

            ingredientContext.Delete(ingredient.Id);

            int newCount = dbContext.Ingredients.Count();
            Assert.That(newCount, Is.EqualTo(initialCount - 1));
        }
    }
}




