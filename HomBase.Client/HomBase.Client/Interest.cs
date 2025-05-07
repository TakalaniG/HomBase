using HomBase.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace HomBase.Client
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Message { get; set; }

        public DateTime DateExpressed { get; set; } = DateTime.Now;

        public Property Property { get; set; }
        public User User { get; set; }
    }
}

