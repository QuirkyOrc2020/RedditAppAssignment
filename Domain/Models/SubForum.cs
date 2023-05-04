

using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class SubForum
{
    [Key]
    public int Id { get; set; }
    public User CreatedBy { get; set; }
    public string Type { get; set; }

    public SubForum(User createdBy, string type)
    {
        CreatedBy = createdBy;
        Type = type;
    }
    
   private SubForum(){}
    
}