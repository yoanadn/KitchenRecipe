using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;

public class TagContext : IDb<Tag, int>
{
    private readonly KitchenDbContext dbContext;

    public TagContext(KitchenDbContext context)
    {
        dbContext = context;
    }

    public void Create(Tag item)
    {
        dbContext.Tags.Add(item);
        dbContext.SaveChanges();
    }

    public Tag Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<Tag> query = dbContext.Tags;

        if (useNavigationalProperties)
            query = query.Include(t => t.Recipes);

        if (isReadOnly)
            query = query.AsNoTrackingWithIdentityResolution();

        Tag tag = query.FirstOrDefault(x => x.Id == key);
        if (tag == null)
            throw new KeyNotFoundException();

        return tag;
    }

    public List<Tag> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<Tag> query = dbContext.Tags;

        if (useNavigationalProperties)
            query = query.Include(t => t.Recipes);

        if (isReadOnly)
            query = query.AsNoTrackingWithIdentityResolution();

        return query.ToList();
    }

    public void Update(Tag item, bool useNavigationalProperties = false)
    {
        Tag existing = Read(item.Id, useNavigationalProperties);
        existing.Name = item.Name;
        dbContext.SaveChanges();
    }

    public void Delete(int key)
    {
        Tag tag = Read(key);
        dbContext.Tags.Remove(tag);
        dbContext.SaveChanges();
    }
}
