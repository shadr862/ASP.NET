using ClassroomApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Model;
using Microsoft.AspNetCore.Cors;
using FuzzySharp;
using Microsoft.EntityFrameworkCore;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy_2")]
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

        [HttpGet("student/{studentId}/quiz/{quizId}")]
        public IActionResult GetSubmissionsByStudentId(Guid studentId,Guid quizId)
        {
            var submissions = _context.QuizSubmissions
                .Where(s => s.StudentId == studentId && s.QuizId==quizId)
                .ToList();
            return Ok(submissions);
        }

        [HttpGet("student/{studentId}")]
        public IActionResult GetSubmissionsByStudentId(Guid studentId)
        {
            var submissions = _context.QuizSubmissions
                .Where(s => s.StudentId == studentId)
                .ToList();
            return Ok(submissions);
        }
        [HttpGet("quiz/{quizId}/submissions-with-user")]
        public IActionResult GetSubmissionsWithUserByQuizId(Guid quizId)
        {
            var submissions = _context.QuizSubmissions
                .Where(q => q.QuizId == quizId)
                .Select(q => new
                {
                    SubmissionId = q.Id,
                    QuizId = q.QuizId,
                    StudentId = q.StudentId,
                    Score = q.Score,
                    AnswersJson = q.AnswersJson,
                    Student = new
                    {
                        q.Student.Id,
                        q.Student.FullName,
                        q.Student.Email
                    }
                })
                .ToList();

            return Ok(submissions);
        }





    [HttpPost]
    public IActionResult CreateSubmission([FromBody] ModelDto.CreateUpdateQuizSubmissionDto submissionDto)
    {
        if (submissionDto == null)
            return BadRequest("Submission data is null.");

        var answers = string.IsNullOrEmpty(submissionDto.AnswersJson)
            ? new Dictionary<string, string>()
            : System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(submissionDto.AnswersJson);

        var questions = _context.QuizQuestions
            .Where(q => q.QuizId == submissionDto.QuizId)
            .ToList();

        if (!questions.Any())
            return BadRequest("No questions found for the quiz.");

        double totalScore = 0;
        double maxScore = questions.Count; // 1 point per question

        foreach (var question in questions)
        {
            string key = $"{question.QuizId}_{question.Id}";
            answers.TryGetValue(key, out string userAnswer);

            double questionScore = 0;

            switch (question.QuestionType)
            {
                case "shortQuestion":
                    if (!string.IsNullOrWhiteSpace(userAnswer))
                    {
                        int similarityRatio = Fuzz.Ratio(userAnswer, question.CorrectAnswer ?? "");
                        questionScore = similarityRatio / 100.0;
                    }
                    break;

                case "MCQ":
                case "TrueFalse":
                    if (!string.IsNullOrEmpty(userAnswer) && userAnswer == question.CorrectAnswer)
                    {
                        questionScore = 1;
                    }
                    break;

                default:
                    // If you have other question types, handle here
                    break;
            }

            totalScore += questionScore;
        }

        var submission = new QuizSubmission
        {
            QuizId = submissionDto.QuizId,
            StudentId = submissionDto.StudentId,
            AnswersJson = submissionDto.AnswersJson,
            Score = totalScore
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
