namespace Library.API.Models.DTO.Circulation
{
    public class CreateCirculationDTO
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public required DateTime DueDate { get; set; }
    }
}
