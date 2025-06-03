namespace Library.API.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public bool Deleted { get; set; } = false;
        public required string Name { get; set; }
        public required string Email { get; set; }  
    }
}
