using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebAPI.Service;

public class AuthService: IAuthService
{

    private readonly IList<User> users = new List<User>
    {
        new User
        {
            Age = 27,
            Email = "1234@gmail.com",
            Domain = "via",
            Name = "Chris",
            Password = "1234",
            Role = "Student",
            UserName = "Chris",
            SecurityLevel = 4
        },
        new User
        {
            Age = 22,
            Email = "T@gmail.com",
            Domain = "via",
            Name = "Tina",
            Password = "1234",
            Role = "Student",
            UserName = "Tina",
            SecurityLevel = 4
        },
        new User
        {
        Age = 22,
        Email = "A@gmail.com",
        Domain = "via",
        Name = "ALex",
        Password = "1234",
        Role = "Student",
        UserName = "Alex",
        SecurityLevel = 4
    },
        new User
        {
            Age = 23,
            Email = "L@gmail.com",
            Domain = "via",
            Name = "Lukasz",
            Password = "1234",
            Role = "Student",
            UserName = "Lukasz",
            SecurityLevel = 4
        },
        new User
        {
            Age = 27,
            Email = "A@gmail.com",
            Domain = "via",
            Name = "Adrian",
            Password = "1234",
            Role = "Student",
            UserName = "Adrian",
            SecurityLevel = 4
        },
        new User
        {
            Age = 21,
            Email = "G@gmail.com",
            Domain = "via",
            Name = "Gabi",
            Password = "1234",
            Role = "Student",
            UserName = "Gabi",
            SecurityLevel = 4
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => 
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        
        return Task.CompletedTask;
    }

    public Task LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public Task RegisterAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        throw new NotImplementedException();
    }

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}

