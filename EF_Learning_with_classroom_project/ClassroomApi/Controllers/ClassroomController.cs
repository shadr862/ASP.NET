using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Data;
using ClassroomApi.Model;
using ClassroomApi.ModelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Ensure this controller requires authentication
    [EnableCors("Policy_1")]
    public class ClassroomController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClassroomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClassrooms()
        {
            var classrooms = _context.Classrooms.ToList();
            return Ok(classrooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetClassroom(Guid id)
        {
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null)
                return NotFound();
            return Ok(classroom);
        }

        [HttpGet("by-teacher/{teacherId}")]
        public IActionResult GetClassroomByTeacherId(Guid teacherId)
        {
            var classroom = _context.Classrooms.Where(t=>t.TeacherId == teacherId).ToList();
            if (classroom == null)
                return NotFound();
            return Ok(classroom);
        }
        [HttpPost]
        public IActionResult CreateClassroom([FromBody] CreateUpdateClassroom classroomDto)
        {
            if (string.IsNullOrWhiteSpace(classroomDto.Name) || classroomDto.TeacherId == Guid.Empty)
                return BadRequest("Name and TeacherId are required.");
            var classroom = new Classroom
            {
                Name = classroomDto.Name,
                TeacherId = classroomDto.TeacherId
            };
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClassroom), new { id = classroom.Id }, classroom);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassroom(Guid id, [FromBody] CreateUpdateClassroom classroomDto)
        {
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null)
                return NotFound();
            if (string.IsNullOrWhiteSpace(classroomDto.Name) || classroomDto.TeacherId == Guid.Empty)
                return BadRequest("Name and TeacherId are required.");
            classroom.Name = classroomDto.Name;
            classroom.TeacherId = classroomDto.TeacherId;

            _context.Classrooms.Update(classroom);
            _context.SaveChanges();
            return Ok(classroom);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClassroom(Guid id)
        {
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null)
                return NotFound();
            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
