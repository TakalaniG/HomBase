using System.ComponentModel.DataAnnotations;

namespace HomBaseAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } // "Admin" or "Client"

        public ICollection<Interest> Interests { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
