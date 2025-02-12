namespace HomBase.Client.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateListed { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
    }
}
