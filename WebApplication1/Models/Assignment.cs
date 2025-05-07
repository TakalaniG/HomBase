using HomBaseAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace HomBaseAPI.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Property Property { get; set; }
        public User User { get; set; }
    }
}
