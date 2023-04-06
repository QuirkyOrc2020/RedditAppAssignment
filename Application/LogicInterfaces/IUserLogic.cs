using Domain.DTOs;


namespace Application.LogicInterfaces;

public interface IUserLogic
{
    public Task<User> CreateAsync(UserCreationDto dto);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    Task<User> ValidateUser(string userName, string password);
}