using System;
using System.Linq;
using DataLayer;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace KitchenPresentation
{
    internal class Program
    {
        static KitchenDbContext dbContext;
        static RecipeContext recipeContext;
        static CategoryContext categoryContext;
        static IngredientContext ingredientContext;
        static TagContext tagContext;

        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<KitchenDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=KitchenDb;Trusted_Connection=True;")
                .Options;

            dbContext = new KitchenDbContext(options);
            recipeContext = new RecipeContext(dbContext);
            categoryContext = new CategoryContext(dbContext);
            ingredientContext = new IngredientContext(dbContext);
            tagContext = new TagContext(dbContext);

            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Kitchen Recipe Manager");
                Console.WriteLine("1. Manage Recipes");
                Console.WriteLine("2. Manage Categories");
                Console.WriteLine("3. Manage Ingredients");
                Console.WriteLine("4. Manage Tags");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": RecipeMenu(); break;
                    case "2": CategoryMenu(); break;
                    case "3": IngredientMenu(); break;
                    case "4": TagMenu(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option."); Console.ReadKey(); break;
                }
            }
        }

        static int GetValidIndex(int maxIndex, string prompt = "Enter number: ")
        {
            int index;
            while (true)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > maxIndex)
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }
                else break;
            }
            return index;
        }

        static void AddRecipe()
        {
            Console.Clear();
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Instructions: ");
            string instructions = Console.ReadLine();

            Console.Write("Preparation Time (minutes): ");
            int prepTime = int.Parse(Console.ReadLine());

            Console.Write("Servings: ");
            int servings = int.Parse(Console.ReadLine());

            var categories = categoryContext.ReadAll()
                .OrderBy(c => c.Name)
                .Select((c, index) => new { DisplayId = index + 1, c })
                .ToList();

            Console.WriteLine("Available categories:");
            foreach (var cat in categories)
                Console.WriteLine($"#{cat.DisplayId}: {cat.c.Name}");

            int selectedCategoryDisplayId = GetValidIndex(categories.Count, "Enter category number: ");
            int categoryId = categories.First(c => c.DisplayId == selectedCategoryDisplayId).c.Id;

            var tags = tagContext.ReadAll()
                .OrderBy(t => t.Name)
                .Select((t, index) => new { DisplayId = index + 1, t })
                .ToList();

            Console.WriteLine("Available tags:");
            foreach (var tag in tags)
                Console.WriteLine($"#{tag.DisplayId}: {tag.t.Name}");

            Console.Write("Enter tag numbers (comma-separated): ");
            string input = Console.ReadLine();
            var selectedTagIds = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.TryParse(s.Trim(), out var n) ? n : -1)
                .Where(i => i >= 1 && i <= tags.Count)
                .ToList();

            var selectedTags = tags
                .Where(t => selectedTagIds.Contains(t.DisplayId))
                .Select(t => t.t)
                .ToList();

            Recipe recipe = new Recipe(title, instructions, prepTime, servings, categoryId)
            {
                Tags = selectedTags
            };

            recipeContext.Create(recipe);
            Console.WriteLine("Recipe added.");
            Console.ReadKey();
        }

        static void ListRecipes()
        {
            Console.Clear();
            var recipes = recipeContext.ReadAll(true)
                .OrderBy(r => r.Title)
                .Select((r, index) => new { DisplayId = index + 1, r });

            foreach (var r in recipes)
            {
                Console.WriteLine($"#{r.DisplayId} - {r.r.Title} ({r.r.PreparationTime} min)");
                Console.WriteLine($"Category: {r.r.Category?.Name}");
                Console.WriteLine($"Servings: {r.r.Servings}");
                Console.WriteLine($"Instructions: {r.r.Instructions}");

                if (r.r.Tags != null && r.r.Tags.Any())
                {
                    var tagList = string.Join(", ", r.r.Tags.Select(t => t.Name));
                    Console.WriteLine($"Tags: {tagList}");
                }

                Console.WriteLine("----------------------------");
            }
            Console.ReadKey();
        }

        static void DeleteEntity<T>(Func<List<(int DisplayId, T Entity)>> getList, Action<int> deleteAction)
        {
            var list = getList();
            foreach (var item in list)
            {
                string display = item.Entity switch
                {
                    Recipe r => $"#{item.DisplayId}: {r.Title}",
                    Category c => $"#{item.DisplayId}: {c.Name}",
                    Tag t => $"#{item.DisplayId}: {t.Name}",
                    Ingredient i => $"#{item.DisplayId}: {i.Name} ({i.Quantity}) - Recipe: {i.Recipe?.Title}",
                    _ => $"#{item.DisplayId}: {item.Entity.ToString()}"
                };
                Console.WriteLine(display);
            }

            int index = GetValidIndex(list.Count);
            int id = list.First(x => x.DisplayId == index).Entity switch
            {
                Recipe r => r.Id,
                Category c => c.Id,
                Tag t => t.Id,
                Ingredient i => i.Id,
                _ => -1
            };

            deleteAction(id);
            Console.WriteLine("Deleted.");
            Console.ReadKey();
        }

        static void DeleteRecipe() => DeleteEntity(
            () => recipeContext.ReadAll(true).OrderBy(r => r.Title).Select((r, i) => (i + 1, (object)r)).ToList()
                .Select(t => ((int)t.Item1, (Recipe)t.Item2)).ToList(),
            id => recipeContext.Delete(id));

        static void DeleteCategory() => DeleteEntity(
            () => categoryContext.ReadAll().OrderBy(c => c.Name).Select((c, i) => (i + 1, c)).ToList(),
            id => categoryContext.Delete(id));

        static void DeleteTag() => DeleteEntity(
            () => tagContext.ReadAll().OrderBy(t => t.Name).Select((t, i) => (i + 1, t)).ToList(),
            id => tagContext.Delete(id));

        static void DeleteIngredient() => DeleteEntity(
            () => ingredientContext.ReadAll(true).OrderBy(i => i.Name).Select((i, index) => (index + 1, i)).ToList(),
            id => ingredientContext.Delete(id));

        static void RecipeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Recipe Menu");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. List Recipes");
                Console.WriteLine("3. Delete Recipe");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddRecipe(); break;
                    case "2": ListRecipes(); break;
                    case "3": DeleteRecipe(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); Console.ReadKey(); break;
                }
            }
        }

        static void CategoryMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Categories");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. List Categories");
                Console.WriteLine("3. Delete Category");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        categoryContext.Create(new Category(name));
                        Console.WriteLine("Added.");
                        Console.ReadKey();
                        break;
                    case "2":
                        var list = categoryContext.ReadAll()
                            .OrderBy(c => c.Name)
                            .Select((c, index) => new { DisplayId = index + 1, c.Name });
                        foreach (var c in list)
                            Console.WriteLine($"#{c.DisplayId}: {c.Name}");
                        Console.ReadKey();
                        break;
                    case "3": DeleteCategory(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid."); Console.ReadKey(); break;
                }
            }
        }

        static void IngredientMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingredients");
                Console.WriteLine("1. Add Ingredient");
                Console.WriteLine("2. List Ingredients");
                Console.WriteLine("3. Delete Ingredient");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Quantity: ");
                        string qty = Console.ReadLine();
                        Console.Write("Recipe ID: ");
                        int recipeId = int.Parse(Console.ReadLine());
                        ingredientContext.Create(new Ingredient(name, qty, recipeId));
                        Console.WriteLine("Added.");
                        Console.ReadKey();
                        break;
                    case "2":
                        var list = ingredientContext.ReadAll(true)
                            .OrderBy(i => i.Name)
                            .Select((i, index) => new { DisplayId = index + 1, i });
                        foreach (var i in list)
                            Console.WriteLine($"#{i.DisplayId}: {i.i.Name} ({i.i.Quantity}) - Recipe: {i.i.Recipe?.Title}");
                        Console.ReadKey();
                        break;
                    case "3": DeleteIngredient(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid."); Console.ReadKey(); break;
                }
            }
        }

        static void TagMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tags");
                Console.WriteLine("1. Add Tag");
                Console.WriteLine("2. List Tags");
                Console.WriteLine("3. Delete Tag");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        tagContext.Create(new Tag(name));
                        Console.WriteLine("Added.");
                        Console.ReadKey();
                        break;
                    case "2":
                        var list = tagContext.ReadAll()
                            .OrderBy(t => t.Name)
                            .Select((t, index) => new { DisplayId = index + 1, t.Name });
                        foreach (var t in list)
                            Console.WriteLine($"#{t.DisplayId}: {t.Name}");
                        Console.ReadKey();
                        break;
                    case "3": DeleteTag(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid."); Console.ReadKey(); break;
                }
            }
        }
    }
}
