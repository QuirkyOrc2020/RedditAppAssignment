namespace Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public User WrittenBy { get; set; }
    public int PostedOn { get; set; }
    public string Body { get; set; }
    public int? ParentCommentId { get; set; }

    public Comment(User writtenBy, int postedOn, string body, int? parentCommentId)
    {
        WrittenBy = writtenBy;
        Body = body;
        ParentCommentId = parentCommentId;
        PostedOn = postedOn;
    }

    private Comment() { }
}