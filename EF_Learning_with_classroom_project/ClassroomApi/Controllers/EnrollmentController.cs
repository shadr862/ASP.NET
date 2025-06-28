using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Data;
using ClassroomApi.ModelDto;
namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var enrollments = _context.Enrollments.ToList();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult Post(CreateUpdateEnrollmentDto enrollmentDto)
        {
            if (enrollmentDto == null)
            {
                return BadRequest("Enrollment data is null.");
            }
            var enrollment = new Model.Enrollment
            {
                ClassroomId = enrollmentDto.ClassroomId,
                StudentId = enrollmentDto.StudentId
            };
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = enrollment.Id }, enrollment);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CreateUpdateEnrollmentDto enrollmentDto)
        {
            if (enrollmentDto == null)
            {
                return BadRequest("Enrollment data is null.");
            }
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            enrollment.ClassroomId = enrollmentDto.ClassroomId;
            enrollment.StudentId = enrollmentDto.StudentId;
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
