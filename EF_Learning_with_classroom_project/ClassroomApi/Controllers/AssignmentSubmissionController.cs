using ClassroomApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Model;
using ClassroomApi.ModelDto;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSubmissionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentSubmissionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllSubmissions()
        {
            var submissions = _context.AssignmentSubmissions.ToList();
            return Ok(submissions);
        }


        [HttpGet("{id}")]
        public IActionResult GetSubmissionById(Guid id)
        {
            var submission = _context.AssignmentSubmissions.Find(id);
            if (submission == null)
            {
                return NotFound();
            }
            return Ok(submission);
        }

        [HttpGet("assignment/{assignmentId}/{studentId}")]

        public IActionResult GetSubmissionByAssignmentAndStudent(Guid assignmentId, Guid studentId)
        {
            var submission = _context.AssignmentSubmissions
                .Where(a => a.AssignmentId == assignmentId && a.StudentId == studentId).ToList();
            if (submission == null)
            {
                return NotFound();
            }
            return Ok(submission);
        }

        [HttpPost]
        public IActionResult CreateSubmission(CreateUpdateAssignmentSubmissionDto submissionDto)
        {
            if (submissionDto == null)
            {
                return BadRequest("Invalid submission data.");
            }
            var submission = new AssignmentSubmission
            {
                AssignmentId = submissionDto.AssignmentId,
                StudentId = submissionDto.StudentId,
                FilePath = submissionDto.FilePath,
                Grade = submissionDto.Grade
            };
            _context.AssignmentSubmissions.Add(submission);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubmission(Guid id, CreateUpdateAssignmentSubmissionDto submissionDto)
        {
            if (submissionDto == null || id != submissionDto.AssignmentId)
            {
                return BadRequest("Invalid submission data.");
            }
            var submission = _context.AssignmentSubmissions.Find(id);
            if (submission == null)
            {
                return NotFound();
            }
            submission.FilePath = submissionDto.FilePath;
            submission.Grade = submissionDto.Grade;
            _context.AssignmentSubmissions.Update(submission);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubmission(Guid id)
        {
            var submission = _context.AssignmentSubmissions.Find(id);
            if (submission == null)
            {
                return NotFound();
            }
            _context.AssignmentSubmissions.Remove(submission);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
