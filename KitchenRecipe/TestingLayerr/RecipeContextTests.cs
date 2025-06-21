using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLayer
{
    [TestFixture]
    public class RecipeContextTests
    {
        static RecipeContext recipeContext;

        static RecipeContextTests()
        {
            recipeContext = new RecipeContext(TestManager.dbContext);
        }

        [Test]
        public void CreateRecipe()
        {
            Recipe recipe = new Recipe("Cake", "Mix and bake", 30, 4, 1);
            int before = TestManager.dbContext.Recipes.Count();

            recipeContext.Create(recipe);

            int after = TestManager.dbContext.Recipes.Count();
            Recipe last = TestManager.dbContext.Recipes.Last();
            Assert.That(after == before + 1 && last.Title == recipe.Title);
        }

        [Test]
        public void ReadRecipe()
        {
            Recipe r = new Recipe("Cake", "Bake it", 25, 2, 1);
            recipeContext.Create(r);

            Recipe read = recipeContext.Read(r.Id);

            Assert.That(read.Title == r.Title);
        }

        [Test]
        public void ReadAllRecipes()
        {
            int dbCount = TestManager.dbContext.Recipes.Count();
            int contextCount = recipeContext.ReadAll().Count;
            Assert.That(dbCount == contextCount);
        }

        [Test]
        public void UpdateRecipe()
        {
            Recipe r = new Recipe("Old", "Text", 20, 2, 1);
            recipeContext.Create(r);
            r = recipeContext.ReadAll().Last();
            r.Title = "Updated";

            recipeContext.Update(r);

            Assert.That(recipeContext.Read(r.Id).Title == "Updated");
        }

        [Test]
        public void DeleteRecipe()
        {
            Recipe r = new Recipe("Delete me", "Text", 10, 1, 1);
            recipeContext.Create(r);
            int before = recipeContext.ReadAll().Count;
            int id = recipeContext.ReadAll().Last().Id;

            recipeContext.Delete(id);

            Assert.That(recipeContext.ReadAll().Count == before - 1);
        }

        [Test]
        public void DeleteRecipeInvalid()
        {
            Recipe r = new Recipe("Invalid delete", "text", 10, 1, 1);
            recipeContext.Create(r);
            int id = recipeContext.ReadAll().Last().Id;
            recipeContext.Delete(id);

            Assert.Throws<KeyNotFoundException>(() => recipeContext.Read(id));
        }
    }

}
