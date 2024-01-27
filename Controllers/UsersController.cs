using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    // Controllers/UsersController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("getallusers")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _userRepository.GetAllUsers().ToList();
        }

        [HttpGet("displayuserlist")]
        public ActionResult<IEnumerable<User>> DisplayUserList()
        {
            // This method can be used for displaying the user list in a specific format or with additional details.
            return _userRepository.GetAllUsers().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // co class create user dto nen minh nen chon class do de truyen vo api
        [HttpPost("createuser")]
        public IActionResult AddUser([FromBody] UserCreateDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // convert from user dto to user domain
            var userDomain = new User
            {
                Name = user.Name,
                Age = user.Age,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
            };

            _userRepository.AddUser(userDomain);

            return CreatedAtAction(nameof(GetUserById), new { id = userDomain.Id }, user);
        }

        [HttpPut("updateuser/{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] User user)
        {
            if (user == null || id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.UpdateUser(user);

            return NoContent();
        }

        [HttpPost("giveroletouser/{id}")]
        public IActionResult AddRoleToUser(int id, [FromBody] string roleName)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.AddRoleToUser(id, roleName);

            return NoContent();
        }

        [HttpDelete("deleteuser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(id);

            return NoContent();
        }
    }

}

