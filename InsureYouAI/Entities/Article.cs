namespace InsureYouAI.Entities;

public class Article
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate  { get; set; }
    public string Content { get; set; }
    public string MainCoverImageUrl { get; set; }
    public string CoverImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}