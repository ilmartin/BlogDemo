using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
    public class UserRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required, Range(1, 5)]
        public int Rating { get; set; } // Rating from 1 to 5

        [Required]
        public string UserName { get; set; } // Name of the user who rated

        [ForeignKey("PostId")]
        public Post Post { get; set; }

    }
}
