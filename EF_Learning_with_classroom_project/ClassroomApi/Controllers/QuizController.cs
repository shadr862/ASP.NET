using ClassroomApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.ModelDto;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetQuizzes()
        {
            var quizzes = _context.Quizzes.ToList();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuiz(Guid id)
        {
            var quiz = _context.Quizzes.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpGet("classId/{id}")]
        public IActionResult GetQuizByQuizId(Guid Id)
        {
            var quiz = _context.Quizzes.Where(q=>q.ClassroomId== Id).ToList();
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpPost]
        public IActionResult CreateQuiz(CreateUpdateQuizDto quizDto)
        {
            if (quizDto == null)
            {
                return BadRequest("Quiz data is null.");
            }
            var quiz = new Model.Quiz
            {
                Title = quizDto.Title,
                Deadline = quizDto.Deadline,
                ClassroomId = quizDto.ClassroomId
            };
            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetQuiz), new { id = quiz.Id }, quiz);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuiz(Guid id, CreateUpdateQuizDto quizDto)
        {
            if (quizDto == null)
            {
                return BadRequest("Quiz data is null.");
            }
            var quiz = _context.Quizzes.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }
            quiz.Title = quizDto.Title;
            quiz.Deadline = quizDto.Deadline;
            quiz.ClassroomId = quizDto.ClassroomId;
            _context.Quizzes.Update(quiz);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz(Guid id)
        {
            var quiz = _context.Quizzes.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }
            _context.Quizzes.Remove(quiz);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
