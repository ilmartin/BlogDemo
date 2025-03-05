using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required, MaxLength(1000)]
        public string Text { get; set; } // User comment text

        [Required]
        public string UserName { get; set; } // Name of the user who commented

        public DateTime CreatedAt { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
