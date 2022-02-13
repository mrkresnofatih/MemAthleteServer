using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MemAthleteServer.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int PostId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Body { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Required]
        [Range(5, 20)]
        public int Likes { get; set; }
        
        [Required]
        public string Hyperlink { get; set; }
        
        [Required]
        public int Dislikes { get; set; }
        
        public List<Comment> Comments { get; set; }
    }

    public class PostCreateUpdateDto
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Body { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Required]
        [Range(5, 20)]
        public int Likes { get; set; }
        
        [Required]
        public string Hyperlink { get; set; }

        [Required]
        public int Dislikes { get; set; }
    }
}