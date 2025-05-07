using HomBaseAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace HomBaseAPI.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }

        public DateTime DateExpressed { get; set; } = DateTime.Now;

        public Property Property { get; set; }
        public User User { get; set; }
    }
}
