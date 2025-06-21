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
    public class TagContextTests
    {
        static TagContext tagContext = new(TestManager.dbContext);

        [Test]
        public void CreateTag()
        {
            Tag tag = new Tag("Vegan");
            int before = tagContext.ReadAll().Count;

            tagContext.Create(tag);

            Assert.That(tagContext.ReadAll().Count == before + 1);
        }

        [Test]
        public void ReadTag()
        {
            Tag tag = new Tag("Healthy");
            tagContext.Create(tag);

            Tag read = tagContext.Read(tag.Id);

            Assert.That(read.Name == "Healthy");
        }

        [Test]
        public void UpdateTag()
        {
            Tag tag = new Tag("Cold");
            tagContext.Create(tag);
            tag = tagContext.ReadAll().Last();
            tag.Name = "Warm";

            tagContext.Update(tag);

            Assert.That(tagContext.Read(tag.Id).Name == "Warm");
        }

        [Test]
        public void DeleteTag()
        {
            Tag tag = new Tag("Spicy");
            tagContext.Create(tag);
            int id = tagContext.ReadAll().Last().Id;

            tagContext.Delete(id);

            Assert.Throws<KeyNotFoundException>(() => tagContext.Read(id));
        }
    }

}
