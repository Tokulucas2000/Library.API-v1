namespace Library.API.Models.DTO.Book
{
    public class CreateBookDTO
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
