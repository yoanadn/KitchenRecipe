using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

namespace DataLayer
{
    public class RecipeContext : IDb<Recipe, int>
    {
        private readonly KitchenDbContext dbContext;

        public RecipeContext(KitchenDbContext context)
        {
            dbContext = context;
        }

        public void Create(Recipe item)
        {
            dbContext.Recipes.Add(item);
            dbContext.SaveChanges();
        }

        public Recipe Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Recipe> query = dbContext.Recipes;

            if (useNavigationalProperties)
            {
                query = query
                    .Include(r => r.Category)
                    .Include(r => r.Ingredients)
                    .Include(r => r.Tags);
            }

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            Recipe recipe = query.FirstOrDefault(x => x.Id == key);
            if (recipe == null)
                throw new KeyNotFoundException();

            return recipe;
        }

        public List<Recipe> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Recipe> query = dbContext.Recipes;

            if (useNavigationalProperties)
            {
                query = query
                    .Include(r => r.Category)
                    .Include(r => r.Ingredients)
                    .Include(r => r.Tags);
            }

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Recipe item, bool useNavigationalProperties = false)
        {
            Recipe existing = Read(item.Id, useNavigationalProperties);

            existing.Title = item.Title;
            existing.Instructions = item.Instructions;
            existing.PreparationTime = item.PreparationTime;
            existing.Servings = item.Servings;
            existing.CategoryId = item.CategoryId;

            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Recipe recipe = Read(key);
            dbContext.Recipes.Remove(recipe);
            dbContext.SaveChanges();
        }
    }
}

