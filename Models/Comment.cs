using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemAthleteServer.Models
{
    public class Comment
    {
        [Key]
        [Required]
        public int CommentId { get; set; }
        
        [ForeignKey("Post")]
        [Required]
        public int PostId { get; set; }
        
        [Required]
        public string Message { get; set; }
    }

    public class CommentCreateUpdateDto
    {
        [Required]
        public int PostId { get; set; }
        
        [Required]
        public string Message { get; set; }
    }
}