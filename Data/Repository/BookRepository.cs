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

        public async Task<List<GetBookDTO>> GetAllBooksAsync()
        {
            var books = await _context.Books.Where(b => !b.Deleted).ToListAsync();
            var listBooks = books.Select(b => new GetBookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                PublishedDate = b.PublishedDate.ToShortDateString()
            }).ToList();
            return listBooks;
        }

        public async Task<GetBookDTO?> GetBookByIdAsync(int id)
        {
            var findBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && !b.Deleted);
            if (findBook == null)
            {
                return null; // or throw an exception based on your error handling strategy
            }
            var book = new GetBookDTO
            {
                Id = findBook.Id,
                Title = findBook.Title,
                Author = findBook.Author,
                ISBN = findBook.ISBN,
                PublishedDate = findBook.PublishedDate.ToShortDateString()
            };
            return book;
        }

        public async Task<GetBookDTO> CreateBookAsync(CreateBookDTO createBookDTO)
        {
            try
            {
                if (createBookDTO == null)
                {
                    throw new ArgumentNullException(nameof(createBookDTO), "CreateBookDTO cannot be null.");
                }

                var validateBook = _context.Books.Any(b => b.ISBN == createBookDTO.ISBN && !b.Deleted);
                if (validateBook)
                {
                    throw new Exception("A book with the same ISBN already exists.");
                }
                var createBook = new Book
                {
                    Title = createBookDTO.Title,
                    Author = createBookDTO.Author,
                    ISBN = createBookDTO.ISBN,
                    PublishedDate = createBookDTO.PublishedDate,
                };
                await _context.Books.AddAsync(createBook);
                await _context.SaveChangesAsync();
                var newBook = new GetBookDTO
                {
                    Id = createBook.Id,
                    Title = createBook.Title,
                    Author = createBook.Author,
                    ISBN = createBook.ISBN,
                    PublishedDate = createBook.PublishedDate.ToShortDateString()
                };
                return newBook;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteBook(int id)
        {
            var findBook = _context.Books.FirstOrDefault(b => b.Id == id && !b.Deleted);
            if (findBook == null)
            {
                throw new InvalidOperationException("Book not found or already deleted.");
            }
            findBook.Deleted = true;
            _context.Update(findBook);
            _context.SaveChanges();
        }

    }
}
