using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Books.Domain.ModelsDb
{
    [Index(nameof(Email))]
    public class UserDb
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
    }
}
