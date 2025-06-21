using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class IngredientContext : IDb<Ingredient, int>
    {
        private readonly KitchenDbContext dbContext;

        public IngredientContext(KitchenDbContext context)
        {
            dbContext = context;
        }

        public void Create(Ingredient item)
        {
            dbContext.Ingredients.Add(item);
            dbContext.SaveChanges();
        }

        public Ingredient Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Ingredient> query = dbContext.Ingredients;

            if (useNavigationalProperties)
                query = query.Include(i => i.Recipe);

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            Ingredient ingredient = query.FirstOrDefault(x => x.Id == key);
            if (ingredient == null)
                throw new KeyNotFoundException();

            return ingredient;
        }

        public List<Ingredient> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Ingredient> query = dbContext.Ingredients;

            if (useNavigationalProperties)
                query = query.Include(i => i.Recipe);

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Ingredient item, bool useNavigationalProperties = false)
        {
            Ingredient existing = Read(item.Id, useNavigationalProperties);
            existing.Name = item.Name;
            existing.Quantity = item.Quantity;
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Ingredient ingredient = Read(key);
            dbContext.Ingredients.Remove(ingredient);
            dbContext.SaveChanges();
        }
    }


}
