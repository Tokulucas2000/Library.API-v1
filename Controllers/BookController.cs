using Library.API.Interface;
using Library.API.Models.DTO.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                var books = _bookRepository.GetAllBooksAsync().Result;
                return Ok(books);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = "An error occurred while retrieving books.", details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var book = _bookRepository.GetBookByIdAsync(id).Result;
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while retrieving the book.", details = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateBookDTO createBookDTO)
        {
            try
            {
                var createdBook = _bookRepository.CreateBookAsync(createBookDTO).Result;

                var getDTO = new GetBookDTO
                {
                    Id = createdBook.Id,
                    Title = createdBook.Title,
                    Author = createdBook.Author,
                    ISBN = createdBook.ISBN,
                    PublishedDate = createdBook.PublishedDate
                };

                return CreatedAtAction(nameof(GetById), new { id = getDTO.Id }, getDTO);
            }           
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while creating the book.", details = ex.InnerException?.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookRepository.DeleteBookAsync(id);
                return Ok("Book deleted with sucess!"); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while deleting the book.", details = ex.Message });
            }
        }
    }
}
