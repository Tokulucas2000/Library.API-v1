using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CirculationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Returning all circulations");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Returning circulation with ID {id}");
        }
        [HttpPost]
        public IActionResult Create()
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, "Circulation created successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent(); // Assuming deletion is successful
        }
    }
}
