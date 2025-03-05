using BlogDemo.Models;
using Markdig;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly BlogContext _context;  // Your database context
    private const int PageSize = 10;  // Number of posts per page

    public HomeController(BlogContext context)
    {
        _context = context;
    }

    public IActionResult Index(int page = 1)
    {
        var totalPosts = _context.Posts.Count();  // Replace with your actual blog posts table
        var totalPages = (int)Math.Ceiling((double)totalPosts / PageSize);

        var blogPosts = _context.Posts
            .OrderByDescending(post => post.CreatedAt)  // Sort by the most recent post
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToList();

        // Convert markdown content to HTML
        foreach (var post in blogPosts)
        {
            post.ContentHtml = Markdown.ToHtml(post.ContentMarkdown);
        }

        ViewData["CurrentPage"] = page;
        ViewData["TotalPages"] = totalPages;

        return View(blogPosts);
    }
}
