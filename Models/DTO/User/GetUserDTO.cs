namespace Library.API.Models.DTO.User
{
    public class GetUserDTO
    {
        public int Id { get; set; }        
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
