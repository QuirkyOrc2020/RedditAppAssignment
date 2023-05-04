using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOs;

public class SubForumEfcDao : ISubForumDao
{
    private readonly SubForumContext context;

    public SubForumEfcDao(SubForumContext context)
    {
        this.context = context;
    }
    public async Task<SubForum> CreateAsync(SubForum subForum)
    {
        EntityEntry<SubForum> added = await context.SubForums.AddAsync(subForum);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<SubForum>> GetAsync()
    {
        IList<SubForum> list = await context.SubForums.ToListAsync();
        return list;
    }

    public async Task DeleteAsync(int id)
    {
        SubForum? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Subforum with id {id} not found");
        }

        context.SubForums.Remove(existing);
        await context.SaveChangesAsync();
    }

    public  async Task<SubForum?> GetByTypeAsync(string type)
    {
        SubForum? queryable  = context.SubForums.SingleOrDefault(forum => forum.Type.Equals(type));
        return queryable;
    }

    public async Task<SubForum?> GetByIdAsync(int belongsToId)
    {
        SubForum? existing = await context.SubForums.FirstOrDefaultAsync(u =>
            u.Id == belongsToId);
        return existing;
    }

    public async Task UpdateAsync(SubForum updated)
    {
        context.SubForums.Update(updated);
        await context.SaveChangesAsync();
    }
}