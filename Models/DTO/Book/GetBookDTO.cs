namespace Library.API.Models.DTO.Book
{
    public class GetBookDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? ISBN { get; set; }
        public string PublishedDate { get; set; }
    }
}
