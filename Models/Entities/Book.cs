namespace Library.API.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
