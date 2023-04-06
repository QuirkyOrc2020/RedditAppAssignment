namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    
    public string Domain { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }

    public UserCreationDto(string userName, string password, string domain, string email, string name, string role, int age)
    {
        UserName = userName;
        Password = password;
        Domain = domain;
        Email = email;
        Name = name;
        Role = role;
        Age = age;
    }
}