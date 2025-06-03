using Library.API.Models.DTO.Book;
using Library.API.Models.Entities;

namespace Library.API.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(CreateBookDTO createBookDTO);
        Task<bool> DeleteBookAsync(int id);
    }
}
