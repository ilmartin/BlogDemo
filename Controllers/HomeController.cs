using BlogDemo.Models;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
            .Include(p => p.Ratings)
            .OrderByDescending(post => post.CreatedAt)  // Sort by the most recent post
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToList();

        // Convert markdown content to HTML
        //foreach (var post in blogPosts)
        //{
        //    post.ContentHtml = Markdown.ToHtml(post.ContentMarkdown);
        //}

        ViewData["CurrentPage"] = page;
        ViewData["TotalPages"] = totalPages;


        return View(blogPosts);
    }

    public IActionResult Post(int id)
    {
        var post = _context.Posts
            .Include(p => p.Ratings)
            .Include(p => p.Comments) // Include comments related to the post
            .FirstOrDefault(p => p.Id == id);

        if (post == null)
        {
            return NotFound();
        }

        // Convert Markdown to HTML
        //post.ContentHtml = Markdown.ToHtml(post.ContentMarkdown);

        // Calculate average rating
        double averageRating = post.Ratings.Any() ? post.Ratings.Average(r => r.Rating) : 0;
        ViewData["AverageRating"] = averageRating;

        return View(post);
    }

    [HttpPost]
    public IActionResult AddComment(int postId, string userName, string text)
    {
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(text))
        {
            TempData["Error"] = "Both name and comment are required.";
            return RedirectToAction("Post", new { id = postId });
        }

        var comment = new Comment
        {
            PostId = postId,
            UserName = userName,
            Text = text,
            CreatedAt = DateTime.UtcNow
        };

        _context.Comments.Add(comment);
        _context.SaveChanges();

        return RedirectToAction("Post", new { id = postId });
    }
}
