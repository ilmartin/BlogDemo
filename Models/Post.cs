using Markdig;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BlogDemo.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string ContentMarkdown { get; set; }
        public string ContentHtml
        {
            get
            {
                return Markdown.ToHtml(ContentMarkdown);
            }
        }


        public string Author { get; set; } // Author name

        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<UserRating> Ratings { get; set; }
        public double AverageRating
        {
            get
            {
                return Ratings != null && Ratings.Any() ? Ratings.Average(r => r.Rating) : 0;
            }
        }
        public ICollection<Comment> Comments { get; set; }

    }
}
