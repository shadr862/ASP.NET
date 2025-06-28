using ClassroomApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.ModelDto;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizQuestionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public QuizQuestionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllQuizQuestions()
        {
            var quizQuestions = _context.QuizQuestions.ToList();
            return Ok(quizQuestions);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuizQuestionById(Guid id)
        {
            var quizQuestion = _context.QuizQuestions.Find(id);
            if (quizQuestion == null)
            {
                return NotFound();
            }
            return Ok(quizQuestion);
        }

        [HttpGet("QuizId/{id}")]
        public IActionResult GetQuizQuestionByQuizId(Guid Id)
        {
            var quizQuestion = _context.QuizQuestions.Where(q=>q.QuizId==Id).ToList();
            if (quizQuestion == null)
            {
                return NotFound();
            }
            return Ok(quizQuestion);
        }

        [HttpPost]
        public IActionResult CreateQuizQuestion(CreateUpdateQuizQuestionDto quizQuestion)
        {
            if (quizQuestion == null)
            {
                return BadRequest("Quiz question cannot be null.");
            }
            var newQuizQuestion = new Model.QuizQuestion
            {
                QuizId = quizQuestion.QuizId,
                QuestionType = quizQuestion.QuestionType,
                QuestionText = quizQuestion.QuestionText,
                OptionA = quizQuestion.OptionA,
                OptionB = quizQuestion.OptionB,
                OptionC = quizQuestion.OptionC,
                OptionD = quizQuestion.OptionD,
                CorrectAnswer = quizQuestion.CorrectAnswer
            };

            _context.QuizQuestions.Add(newQuizQuestion);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetQuizQuestionById), new { id = newQuizQuestion.Id }, newQuizQuestion);

        }


        [HttpPut("{id}")]
        public IActionResult UpdateQuizQuestion(Guid id, CreateUpdateQuizQuestionDto quizQuestion)
        {
            if (quizQuestion == null)
            {
                return BadRequest("Quiz question cannot be null.");
            }
            var existingQuizQuestion = _context.QuizQuestions.Find(id);
            if (existingQuizQuestion == null)
            {
                return NotFound();
            }
            existingQuizQuestion.QuestionType = quizQuestion.QuestionType;
            existingQuizQuestion.QuestionText = quizQuestion.QuestionText;
            existingQuizQuestion.OptionA = quizQuestion.OptionA;
            existingQuizQuestion.OptionB = quizQuestion.OptionB;
            existingQuizQuestion.OptionC = quizQuestion.OptionC;
            existingQuizQuestion.OptionD = quizQuestion.OptionD;
            existingQuizQuestion.CorrectAnswer = quizQuestion.CorrectAnswer;
            _context.QuizQuestions.Update(existingQuizQuestion);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuizQuestion(Guid id)
        {
            var quizQuestion = _context.QuizQuestions.Find(id);
            if (quizQuestion == null)
            {
                return NotFound();
            }
            _context.QuizQuestions.Remove(quizQuestion);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
