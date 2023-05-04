using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly SubForumContext context;

    public PostEfcDao(SubForumContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(string? subForm)
    {
        IQueryable<Post> queryable  = context.Posts.Where(post => post.BelongsTo.Type.Equals(subForm));
        return queryable.ToList();
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? found = await context.Posts
            .AsNoTracking()
            .Include(post => post.BelongsTo.Id)
            .SingleOrDefaultAsync(post => post.BelongsTo.Id == post.Id);
        return found;
    }

    public async Task DeleteAsync(int id)
    {
        Post? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Post updated)
    {
        context.Posts.Update(updated);
        await context.SaveChangesAsync();
    }
}