using Application.DaoInterfaces;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class CommentEfcDao: ICommentDao
{
    public Task<Comment> CreateAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Comment>> GetAsync(int? postId)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Comment updated)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Comment>> GetSubCommentsAsync(int id)
    {
        throw new NotImplementedException();
    }
}