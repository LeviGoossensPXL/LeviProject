using System.ComponentModel.DataAnnotations;
using ClassLibraryLevi.helpers;

namespace WebApplicationLevi.Models
{
    public class PostArticleModel
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishedTime { get; set; }

        [Required, MaxLength(50)]
        public string AuthorName { get; set; }

        [Required]
        public Category Category { get; set; }
        
    }
}
