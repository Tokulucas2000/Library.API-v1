//using Library.API.Interface;
//using Library.API.Models.DTO.Circulation;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Library.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CirculationController : ControllerBase
//    {
//        private readonly ICirculationRepository _circulationRepository;
//        public CirculationController(ICirculationRepository circulationRepository)
//        {
//            _circulationRepository = circulationRepository;
//        }
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            try
//            {
//                var circulations = _circulationRepository.GetAllCirculationsAsync().Result;
//                return Ok(circulations);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = "An error occurred while retrieving circulations.", details = ex.InnerException?.Message });
//            }
//        }
//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            try
//            {
//                var circulation = _circulationRepository.GetCirculationByIdAsync(id).Result;
//                return Ok(circulation);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = "An error occurred while retrieving the circulation.", details = ex.InnerException?.Message });
//            }
//        }
//        [HttpPost]
//        public IActionResult Create([FromBody] CreateCirculationDTO createCirculationDTO)
//        {
//            try
//            {
//                var createdCirculation = _circulationRepository.CreateCirculationAsync(createCirculationDTO).Result;
//                return Ok(createdCirculation);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = "An error occurred while creating the circulation.", details = ex.InnerException?.InnerException?.Message });
//            }
//        }
//        [HttpPut]
//        public IActionResult Update([FromBody] ReturnCirculationDTO returnCirculationDTO)
//        {
//            try
//            {
//                var updatedCirculation = _circulationRepository.UpdateCirculationAsync(returnCirculationDTO).Result;
//                return Ok(updatedCirculation);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = "An error occurred while updating the circulation.", details = ex.InnerException?.Message });
//            }
//        }
//    }
//}
