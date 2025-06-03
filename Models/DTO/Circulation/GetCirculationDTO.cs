namespace Library.API.Models.DTO.Circulation
{
    public class GetCirculationDTO
    {
        public int Id { get; set; }
        public required int BookId { get; set; }
        public required string BookName { get; set; }
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string BorrowedDate { get; set; }
        public required string DueDate { get; set; }
        public string? ReturnedDate { get; set; }
        public required string Status { get; set; }
    }
}
