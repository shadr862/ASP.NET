using ClassroomApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.ModelDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy_2")]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizzes()
        {
            var quizzes = await _context.Quizzes.ToListAsync();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(Guid id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpGet("classId/{id}")]
        public async Task<IActionResult> GetQuizzesByClassroomId(Guid id)
        {
            var quizzes = await _context.Quizzes
                .Where(q => q.ClassroomId == id)
                .ToListAsync();

            if (quizzes == null || !quizzes.Any())
            {
                return NotFound($"No quizzes found for ClassroomId: {id}");
            }

            return Ok(quizzes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateUpdateQuizDto quizDto)
        {
            if (quizDto == null)
            {
                return BadRequest("Quiz data is null.");
            }

            var quiz = new Model.Quiz
            {
                Title = quizDto.Title,
                PostedOn = DateTime.UtcNow,
                Deadline = quizDto.Deadline,
                ClassroomId = quizDto.ClassroomId
            };

            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuiz), new { id = quiz.Id }, quiz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz(Guid id, [FromBody] CreateUpdateQuizDto quizDto)
        {
            if (quizDto == null)
            {
                return BadRequest("Quiz data is null.");
            }

            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            quiz.Title = quizDto.Title;
            quiz.Deadline = quizDto.Deadline;
   

            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

