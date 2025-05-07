using HomBase.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace HomBase.Client
{
    public class Assignment
    {
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
        //public User User { get; set; }
    }
}
