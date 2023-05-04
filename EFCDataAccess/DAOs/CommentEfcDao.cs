using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOs;

public class CommentEfcDao : ICommentDao
{
    private readonly SubForumContext context;

    public CommentEfcDao(SubForumContext context)
    {
        this.context = context;
    }
    public async Task<Comment> CreateAsync(Comment comment)
    {
        EntityEntry<Comment> added = await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Comment>> GetAsync(int? postId)
    {
        IQueryable<Comment> queryable  = context.Comments.Where(comment => comment.ParentCommentId.Equals(postId));
        return queryable.ToList();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        Comment? found = await context.Comments
            .AsNoTracking()
            .Include(comment => comment.ParentCommentId.Equals(comment.PostedOn))
            .SingleOrDefaultAsync(comment => comment.ParentCommentId.Equals(comment.PostedOn));
        return found;
    }

    public async Task UpdateAsync(Comment updated)
    {
        context.Comments.Update(updated);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Comment? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Comment with id {id} not found");
        }

        context.Comments.Remove(existing);
        await context.SaveChangesAsync();
    }

    public Task<IEnumerable<Comment>> GetSubCommentsAsync(int id)
    {
        IEnumerable<Comment> comments = context.Comments.AsEnumerable();
        comments = comments.Where(comment => comment.ParentCommentId == id);
        return Task.FromResult(comments);
    }
}