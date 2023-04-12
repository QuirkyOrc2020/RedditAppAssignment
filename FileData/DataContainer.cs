

using Domain.Models;

namespace FileData;

public class DataContainer
{
    public List<User> Users { get; set; }
    public List<SubForum> SubForums { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Comment> Comments { get; set; }



}