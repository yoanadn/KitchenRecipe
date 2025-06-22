using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Windows.Forms;

namespace KitchenGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var options = new DbContextOptionsBuilder<KitchenDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=KitchenDb;Trusted_Connection=True;")
                .Options;

            var dbContext = new KitchenDbContext(options);
            var categoryContext = new CategoryContext(dbContext);
            var ingredientContext = new IngredientContext(dbContext);
            var recipeContext = new RecipeContext(dbContext);
            var tagContext = new TagContext(dbContext);

            Application.Run(new MainForm(recipeContext, categoryContext, ingredientContext, tagContext));
        }
    }
}
