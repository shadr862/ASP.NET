using ClassroomApi.Data;
using ClassroomApi.Model;
using ClassroomApi.ModelDto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy_2")]
    public class AssignmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAssignments()
        {
            var assignments = _context.Assignments.ToList();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public IActionResult GetAssignment(Guid id)
        {
            var assignment = _context.Assignments.FirstOrDefault(a => a.Id == id);
            if (assignment == null)
                return NotFound();

            return Ok(assignment);
        }

        [HttpGet("classId/{Id}")]
        public IActionResult GetAssignmentsByClassroom(Guid Id)
        {
            var assignments = _context.Assignments
                .Where(a => a.ClassroomId == Id)
                .ToList();
            return Ok(assignments);
        }

        [HttpPost]
        public IActionResult CreateAssignment([FromBody] CreateUpdateAssignmentDto dto)
        {
            if (dto == null)
                return BadRequest("Assignment data is missing.");

            var newAssignment = new Assignment
            {
                Id = Guid.NewGuid(),
                ClassroomId = dto.ClassroomId,
                Title = dto.Title,
                PostedOn = DateTime.UtcNow,
                Description = dto.Description,
                DueDate = dto.DueDate
            };

            _context.Assignments.Add(newAssignment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAssignment), new { id = newAssignment.Id }, newAssignment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(Guid id, [FromBody] CreateUpdateAssignmentDto dto)
        {
            if (dto == null)
                return BadRequest("Assignment data is missing.");

            var assignment = _context.Assignments.FirstOrDefault(a => a.Id == id);
            if (assignment == null)
                return NotFound();

            assignment.Title = dto.Title;
            assignment.Description = dto.Description;
            assignment.DueDate = dto.DueDate;

            _context.SaveChanges();

            return Ok(assignment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(Guid id)
        {
            var assignment = _context.Assignments.FirstOrDefault(a => a.Id == id);
            if (assignment == null)
                return NotFound();

            _context.Assignments.Remove(assignment);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

