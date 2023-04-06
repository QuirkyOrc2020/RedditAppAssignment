

using System.Text.Json.Serialization;
using Domain.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
    public int SecurityLevel { get; set; }
    [JsonIgnore]
    public ICollection<SubForum>SubForums { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Comment> Comments { get; set; }

}