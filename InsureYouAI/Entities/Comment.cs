namespace InsureYouAI.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public string CommentDetail { get; set; }
    public DateTime CommentDate { get; set; }
    public AppUser AppUser { get; set; }
    public string AppUserId { get; set; }
    public Article Article { get; set; }
    public Guid ArticleId { get; set; }
    public string CommentStatus { get; set; }
}