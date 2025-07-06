using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Data;
using ClassroomApi.ModelDto;
using ClassroomApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy_2")]
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

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetClassesByStudent(Guid studentId)
        {
            var studentExists = await _context.Users.AnyAsync(u => u.Id == studentId);
            if (!studentExists)
                return NotFound("Student not found.");

            var classrooms = await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Classroom)
                .Select(e => e.Classroom)
                .ToListAsync();

            return Ok(classrooms);
        }

        [HttpGet("students-by-class/{classroomId}")]
        public async Task<IActionResult> GetEnrolledStudents(Guid classroomId)
        {
            var students = await _context.Enrollments
                .Where(e => e.ClassroomId == classroomId)
                .Include(e => e.Student) // Assuming navigation property exists
                .Select(e => new
                {
                    e.Student.Id,
                    e.Student.FullName,
                    e.Student.Email
                })
                .ToListAsync();

            return Ok(students);
        }


        [HttpPost]
        public IActionResult Post(CreateUpdateEnrollmentDto enrollmentDto)
        {
            if (enrollmentDto == null)
                return BadRequest("Enrollment data is null.");

            var enrollment = new Enrollment
            {
                ClassroomId = enrollmentDto.ClassroomId,
                StudentId = enrollmentDto.StudentId
            };

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = enrollment.Id }, enrollment);
        }

        [HttpPost("join/{accessCode}")]
        public async Task<IActionResult> JoinClass(string accessCode, [FromQuery] Guid studentId)
        {
            if (studentId == Guid.Empty)
                return BadRequest(new { message = "Student ID is required." });

            var classroom = await _context.Classrooms
                .FirstOrDefaultAsync(c => c.AccessCode == accessCode);

            if (classroom == null)
                return NotFound(new { message = "Invalid access code. Class not found." });

            var alreadyEnrolled = await _context.Enrollments
                .AnyAsync(e => e.ClassroomId == classroom.Id && e.StudentId == studentId);

            if (alreadyEnrolled)
                return BadRequest(new { message = "You are already enrolled in this class." });

            var enrollment = new Enrollment
            {
                Id = Guid.NewGuid(),
                ClassroomId = classroom.Id,
                StudentId = studentId
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok(classroom);
        }

        // ✅ Delete by Enrollment ID - renamed route to avoid conflict
        [HttpDelete("by-id/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
                return NotFound("Enrollment not found.");

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ Unenroll a student from a class
        [HttpDelete("unenroll/{classId}")]
        public async Task<IActionResult> UnEnroll(Guid classId, [FromQuery] Guid studentId)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.ClassroomId == classId && e.StudentId == studentId);

            if (enrollment == null)
                return NotFound("Enrollment not found for this student and class.");

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

