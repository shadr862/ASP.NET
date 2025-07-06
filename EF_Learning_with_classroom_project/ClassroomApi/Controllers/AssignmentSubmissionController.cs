using ClassroomApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Model;
using ClassroomApi.ModelDto;
using System.Text.Json;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSubmissionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AssignmentSubmissionController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult GetAllSubmissions()
        {
            var submissions = _context.AssignmentSubmissions.ToList();
            Console.WriteLine($"Found {submissions.Count} submissions.");
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

            var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Uploads");
            var filePath = Path.Combine(uploadsFolder, submission.FilePath);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found on server.");
            }

            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "application/pdf", Path.GetFileName(filePath));
        }

        [HttpGet("file/{assignmentId}/{studentId}")]
        public IActionResult GetSubmissionFileByAssignmentAndStudent(Guid assignmentId, Guid studentId)
        {
            var submission = _context.AssignmentSubmissions
                .FirstOrDefault(s => s.AssignmentId == assignmentId && s.StudentId == studentId);

            if (submission == null)
                return NotFound("Submission not found.");

            var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Uploads");
            var filePath = Path.Combine(uploadsFolder, submission.FilePath);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found on server.");

            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "application/pdf", Path.GetFileName(filePath));
        }

        

    [HttpGet("assignment/{assignmentId}/submissions-with-user")]
    public IActionResult GetSubmissionsWithUserByAssignmentId(Guid assignmentId)
    {
        var submissions = _context.AssignmentSubmissions
            .Where(s => s.AssignmentId == assignmentId)
            .Include(s => s.Student) // ✅ Eager load the Student
            .ToList();

        var result = submissions.Select(s => new
        {
            SubmissionId = s.Id,
            AssignmentId = s.AssignmentId,
            StudentId = s.StudentId,
            Grade = s.Grade,
            FilePath = s.FilePath,
            DownloadUrl = Url.Action(nameof(GetSubmissionFileByAssignmentAndStudent), "AssignmentSubmission",
                new { assignmentId = s.AssignmentId, studentId = s.StudentId }, Request.Scheme),
            Student = new
            {
                s.Student.Id,
                s.Student.FullName,
                s.Student.Email
            }
        }).ToList();

        return Ok(result);
    }




       // Multipart/form-data upload endpoint
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)] // Swagger can't handle multipart + FromForm + string well
       
        public async Task<IActionResult> CreateSubmission([FromForm] IFormFile file, [FromForm] string metadataJson)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            if (string.IsNullOrEmpty(metadataJson))
                return BadRequest("Missing metadata.");

            CreateUpdateAssignmentSubmissionDto submissionDto;
            try
            {
                submissionDto = JsonSerializer.Deserialize<CreateUpdateAssignmentSubmissionDto>(
                metadataJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }
            catch (Exception)
            {
                return BadRequest("Invalid metadata JSON format.");
            }

            var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var submission = new AssignmentSubmission
            {
                Id = Guid.NewGuid(), // Ensure Id is set, otherwise EF might not generate it correctly
                AssignmentId = submissionDto.AssignmentId,
                StudentId = submissionDto.StudentId,
                FilePath = uniqueFileName,
                Grade = 0
            };

            _context.AssignmentSubmissions.Add(submission);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
        }

        // JSON-only creation for testing (no file)
        [HttpPost("json")]
        public IActionResult CreateSubmissionJson([FromBody] CreateUpdateAssignmentSubmissionDto dto)
        {
            var submission = new AssignmentSubmission
            {
                Id = Guid.NewGuid(), // Important: generate new Id
                AssignmentId = dto.AssignmentId,
                StudentId = dto.StudentId,
                FilePath = "dummy.pdf", // placeholder since no file
                Grade = 0
            };

            _context.AssignmentSubmissions.Add(submission);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
        }

        [HttpPut("{id}/grade")]
        public IActionResult UpdateGrade(Guid id, [FromBody] UpdateAssignmentSubmissionGradeDto gradeDto)
        {
            var submission = _context.AssignmentSubmissions.Find(id);
            if (submission == null)
                return NotFound();

            submission.Grade = gradeDto.Grade;
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

            var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Uploads");
            var filePath = Path.Combine(uploadsFolder, submission.FilePath);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.AssignmentSubmissions.Remove(submission);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
