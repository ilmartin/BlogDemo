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
        [NotMapped]
        public string ContentHtml { get; set; } 


        public string Author { get; set; } // Author name

        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<UserRating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
