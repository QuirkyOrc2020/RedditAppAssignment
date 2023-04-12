using Domain;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>?> GetAsync(string? subforum);
    Task<Post?> GetByIdAsync(int id);
    Task CreateAsync(string title, string body, int selectedSubFormId, int ownerId);
    
}