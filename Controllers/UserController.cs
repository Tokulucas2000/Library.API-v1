//using Library.API.Interface;
//using Library.API.Models.DTO.User;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Library.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserRepository _userRepository;
//        public UserController(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            return Ok(_userRepository.GetAllUserAsync().Result);
//        }
//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            try 
//            {
//                var user = _userRepository.GetUserByIdAsync(id).Result;
//                return Ok(user);                
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = "An error occurred while retrieving the user.", details = ex.InnerException?.Message });
//            }
//        }
//        [HttpPost]
//        public IActionResult Create([FromBody] CreateUserDTO createUserDTO)
//        {
//            try
//            {
//                var createuser = _userRepository.CreateUserAsync(createUserDTO).Result;
//                var getDTO = new GetUserDTO
//                {
//                    Id = createuser.Id,
//                    Name = createuser.Name,
//                    Email = createuser.Email
//                };
//                return CreatedAtAction(nameof(GetById), new { id = getDTO.Id }, getDTO);
//            }catch(Exception ex)
//            {
//                return BadRequest(new { message = "An error occurred while creating the user.", details = ex.InnerException?.Message });
//            }
//        }
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            _userRepository.DeleteUser(id);
//            return Ok("User deteled with sucess!");
//        }
//    }
//}
