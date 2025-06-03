using Library.API.Models.DTO.Book;
using Library.API.Models.Entities;

namespace Library.API.Interface
{
    public interface IBookRepository
    {
        Task<List<GetBookDTO>> GetAllBooksAsync();
        Task<GetBookDTO?> GetBookByIdAsync(int id);
        Task<GetBookDTO> CreateBookAsync(CreateBookDTO createBookDTO);
        void DeleteBook(int id);
    }
}
