using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using ClassroomApi.Data;
using ClassroomApi.Model;
using ClassroomApi.ModelDto;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy_2")]
    public class ClassroomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassroomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClassrooms()
        {
            var classrooms = await _context.Classrooms.ToListAsync();
            return Ok(classrooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassroom(Guid id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
                return NotFound();

            return Ok(classroom);
        }

        [HttpGet("by-teacher/{teacherId}")]
        public async Task<IActionResult> GetClassroomByTeacherId(Guid teacherId)
        {
            var classrooms = await _context.Classrooms
                .Where(t => t.UserId == teacherId)
                .ToListAsync();

            return Ok(classrooms);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClassroom([FromBody] CreateUpdateClassroom dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ClassName) || dto.TeacherId == Guid.Empty)
                return BadRequest("ClassName and TeacherId are required.");

            var classroom = new Classroom
            {
                Id = Guid.NewGuid(),
                ClassName = dto.ClassName,
                Description = dto.Description,
                UserId = dto.TeacherId,
                CreatedAt = DateTime.UtcNow,
                AccessCode =Classroom.GenerateAccessCode() // Generate a random access code
            };

            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassroom), new { id = classroom.Id }, classroom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassroom(Guid id, [FromBody] CreateUpdateClassroom dto)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(dto.ClassName) || dto.TeacherId == Guid.Empty)
                return BadRequest("ClassName and TeacherId are required.");

            classroom.ClassName = dto.ClassName;
            classroom.Description = dto.Description;
            classroom.UserId = dto.TeacherId;

            _context.Classrooms.Update(classroom);
            await _context.SaveChangesAsync();

            return Ok(classroom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(Guid id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
                return NotFound();

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        


    }
}
