using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.BlogViewComponents;

public class _BlogListAllBlogsComponentPartial : ViewComponent
{
    private readonly InsureContext _context;
    public _BlogListAllBlogsComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke()
    {
        var values = _context.Articles
            .Include(a=> a.AppUser)
            .Include(k => k.Category)
            .Include(c => c.Comments)
            .Select(a => new ArticleListViewModel
            {
                ArticleId = a.Id,
                Author = a.AppUser.UserName+ " " + a.AppUser.Surname,
                CategoryName = a.Category.Name,
                CreatedDate = a.CreatedDate,
                Content = a.Content,
                ImageUrl = a.CoverImageUrl,
                Title = a.Title,
                CommentCount = a.Comments.Count
            }).ToList();
        return View(values);
    }
}