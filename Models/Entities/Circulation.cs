namespace Library.API.Models.Entities
{
    public class Circulation
    {
        public int Id { get; set; }
        public required int BookId { get; set; }
        public Book Book { get; set; } 
        public required int UserId { get; set; }
        public User User { get; set; }
        public required DateTime BorrowedDate { get; set; }
        public required DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
