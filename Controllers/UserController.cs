using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Returning all users");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Returning user with ID {id}");
        }
        [HttpPost]
        public IActionResult Create()
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, "User created successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent(); // Assuming deletion is successful
        }
    }
}
