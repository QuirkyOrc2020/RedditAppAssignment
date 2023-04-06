using Application.DaoInterfaces;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class SubForumEfcDao : ISubForumDao
{
    public Task<SubForum> CreateAsync(SubForum subForum)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SubForum>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<SubForum?> GetByTypeAsync(string type)
    {
        throw new NotImplementedException();
    }

    public Task<SubForum?> GetByIdAsync(int belongsToId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(SubForum updated)
    {
        throw new NotImplementedException();
    }
}