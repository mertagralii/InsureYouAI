using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.BlogViewComponents;

public class _BlogListByCategoryComponentPartial : ViewComponent
{
    private readonly InsureContext _context;
    public _BlogListByCategoryComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke(Guid categoryId)
    {
        var values = _context.Articles
            .Include(a=> a.AppUser)
            .Include(k => k.Category)
            .Include(c => c.Comments)
            .Where(z=> z.CategoryId == categoryId)
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