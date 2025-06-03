using Library.API.Models.DTO.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok("Returning all books");
        }

        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            return Ok("Returning all books");
        }

        [HttpPost]
        public IActionResult Create(CreateBookDTO createBookDTO)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, "Book created successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent(); // Assuming deletion is successful
        }
    }
}
