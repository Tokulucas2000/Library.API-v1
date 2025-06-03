using Library.API.Interface;
using Library.API.Models.DTO.Book;
using Library.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return null; // or throw an exception based on your error handling strategy
            }
            return await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public Task<Book> CreateBookAsync(CreateBookDTO createBookDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
