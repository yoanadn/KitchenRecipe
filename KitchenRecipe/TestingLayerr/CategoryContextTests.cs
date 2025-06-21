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
    public class CategoryContextTests
    {
        static CategoryContext categoryContext = new(TestManager.dbContext);

        [Test]
        public void CreateCategory()
        {
            Category cat = new Category("Dessert");
            int before = categoryContext.ReadAll().Count;

            categoryContext.Create(cat);

            Assert.That(categoryContext.ReadAll().Count == before + 1);
        }

        [Test]
        public void ReadCategory()
        {
            Category cat = new Category("Soup");
            categoryContext.Create(cat);

            Category read = categoryContext.Read(cat.Id);

            Assert.That(read.Name == "Soup");
        }

        [Test]
        public void UpdateCategory()
        {
            Category cat = new Category("Starter");
            categoryContext.Create(cat);
            cat = categoryContext.ReadAll().Last();
            cat.Name = "Main";

            categoryContext.Update(cat);

            Assert.That(categoryContext.Read(cat.Id).Name == "Main");
        }

        [Test]
        public void DeleteCategory()
        {
            Category cat = new Category("Snacks");
            categoryContext.Create(cat);
            int id = categoryContext.ReadAll().Last().Id;

            categoryContext.Delete(id);

            Assert.Throws<KeyNotFoundException>(() => categoryContext.Read(id));
        }
    }

}
