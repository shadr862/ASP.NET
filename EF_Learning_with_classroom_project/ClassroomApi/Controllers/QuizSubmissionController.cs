using ClassroomApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Model;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizSubmissionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizSubmissionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllSubmissions()
        {
            var submissions = _context.QuizSubmissions.ToList();
            return Ok(submissions);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubmissionById(Guid id)
        {
            var submission = _context.QuizSubmissions.Find(id);
            if (submission == null)
            {
                return NotFound();
            }
            return Ok(submission);
        }

        [HttpGet("student/{studentId}")]
        public IActionResult GetSubmissionsByStudentId(Guid studentId)
        {
            var submissions = _context.QuizSubmissions
                .Where(s => s.StudentId == studentId)
                .ToList();
            return Ok(submissions);
        }

        [HttpPost]
        public IActionResult CreateSubmission([FromBody] ModelDto.CreateUpdateQuizSubmissionDto submissionDto)
        {
            if (submissionDto == null)
            {
                return BadRequest("Submission data is null.");
            }
            var submission = new QuizSubmission
            {
                QuizId = submissionDto.QuizId,
                StudentId = submissionDto.StudentId,
                AnswersJson = submissionDto.AnswersJson,
                Score = submissionDto.Score
            };
            _context.QuizSubmissions.Add(submission);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateSubmission(Guid id, [FromBody] ModelDto.CreateUpdateQuizSubmissionDto submissionDto)
        {
            if (submissionDto == null || id != submissionDto.QuizId)
            {
                return BadRequest("Invalid submission data.");
            }
            var existingSubmission = _context.QuizSubmissions.Find(id);
            if (existingSubmission == null)
            {
                return NotFound();
            }
            existingSubmission.QuizId = submissionDto.QuizId;
            existingSubmission.StudentId = submissionDto.StudentId;
            existingSubmission.AnswersJson = submissionDto.AnswersJson;
            existingSubmission.Score = submissionDto.Score;
            _context.QuizSubmissions.Update(existingSubmission);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubmission(Guid id)
        {
            var submission = _context.QuizSubmissions.Find(id);
            if (submission == null)
            {
                return NotFound();
            }
            _context.QuizSubmissions.Remove(submission);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
