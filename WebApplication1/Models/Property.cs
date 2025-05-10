using HomBaseAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomBaseAPI.Model
{
    public class Property
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for each property
        public string? Title { get; set; }  // Property title (e.g., 3-bedroom house)
        public string? Description { get; set; }  // Detailed description of the property
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }  // Price of the property
        public string Location { get; set; }  // Location of the property
        public int Bedrooms { get; set; }  // Number of bedrooms
        public int Bathrooms { get; set; }  // Number of bathrooms
        public int Size { get; set; }  // Size in square meters
        public string? ImageUrl { get; set; }  // URL for property image
        public DateTime? DateListed { get; set; }
        public bool isOccupied { get; set; }
        public string LocationCode { get; set; } // Date the property was listed 
        public byte[]? ImageData { get; set; }
        //public ICollection<Interest>? Interests { get; set; } = new List<Interest>();
        //public ICollection<Assignment>? Assignments { get; set; } = new List<Assignment>();
    }
}
