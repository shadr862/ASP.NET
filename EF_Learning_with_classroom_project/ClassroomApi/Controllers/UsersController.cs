using ClassroomApi.Data;
using ClassroomApi.ModelDto;
using ClassroomApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ClassroomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public IActionResult CreateUser(UserCreateUpdateDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.FullName) || string.IsNullOrWhiteSpace(userDto.Role))
                return BadRequest("FullName and Role are required.");

            var user = new User
            {
                FullName = userDto.FullName,
                Role = userDto.Role
            };

            _context.Users.Add(user);
            _context.SaveChangesAsync();

            return Ok(user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, UserCreateUpdateDto userDto)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            user.FullName = userDto.FullName;
            user.Role = userDto.Role;

            _context.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult  DeleteUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}


