using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Books.Domain.ModelsDb
{
    
    public class BookDb
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Cover { get; set; }
    }
}
