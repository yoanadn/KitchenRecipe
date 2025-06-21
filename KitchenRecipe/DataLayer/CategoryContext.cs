using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public class CategoryContext : IDb<Category, int>
    {
        private readonly KitchenDbContext dbContext;

        public CategoryContext(KitchenDbContext context)
        {
            dbContext = context;
        }

        public void Create(Category item)
        {
            dbContext.Categories.Add(item);
            dbContext.SaveChanges();
        }

        public Category Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Category> query = dbContext.Categories;

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            Category category = query.FirstOrDefault(x => x.Id == key);
            if (category == null)
                throw new KeyNotFoundException();

            return category;
        }

        public List<Category> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Category> query = dbContext.Categories;

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Category item, bool useNavigationalProperties = false)
        {
            Category existing = Read(item.Id);
            existing.Name = item.Name;
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Category category = Read(key);
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }
    }

}
