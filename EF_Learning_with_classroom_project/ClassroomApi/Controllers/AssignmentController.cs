using ClassroomApi.Data;
using ClassroomApi.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Model;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpGet("classroom/{classroomId}")]
        public IActionResult GetAssignmentsByClassroom(Guid classroomId)
        {
            var assignments = _context.Assignments
                .Where(a => a.ClassroomId == classroomId)
                .ToList();
            return Ok(assignments);
        }

        [HttpPost]
        public IActionResult CreateAssignment([FromBody] CreateUpdateAssignmentDto assignment)
        {
            if (assignment == null)
            {
                return BadRequest("Assignment cannot be null.");
            }
            var newAssignment = new Assignment
            {
                ClassroomId = assignment.ClassroomId,
                Title = assignment.Title,
                Description = assignment.Description,
                DueDate = assignment.DueDate
            };

            _context.Assignments.Add(newAssignment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAssignment), new { id = newAssignment.Id }, newAssignment);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(Guid id, [FromBody] CreateUpdateAssignmentDto assignmentDto)
        {
            if (assignmentDto == null || id != assignmentDto.ClassroomId)
            {
                return BadRequest("Invalid assignment data.");
            }
            var assignment = _context.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }
            assignment.Title = assignmentDto.Title;
            assignment.Description = assignmentDto.Description;
            assignment.DueDate = assignmentDto.DueDate;
            _context.SaveChanges();
            return Ok(assignment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(Guid id)
        {
            var assignment = _context.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }
            _context.Assignments.Remove(assignment);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
