namespace InsureYouAI.Models;

public class CategoryArticleCountViewModel
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int ArticleCount { get; set; }
}