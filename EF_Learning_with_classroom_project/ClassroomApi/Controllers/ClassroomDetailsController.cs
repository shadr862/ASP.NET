using ClassroomApi.Data;
using ClassroomApi.Model;
using ClassroomApi.ModelDto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/classroom-details")]
[EnableCors("Policy_2")] // Ensure CORS policy is applied
public class ClassroomDetailsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClassroomDetailsController(AppDbContext context)
    {
        _context = context;
    }

    // ✅ GET all details (Announcements + Assignments + Quizzes) for a classroom
    [HttpGet("{classroomId}")]
    public async Task<IActionResult> GetDetailsByClassroom(Guid classroomId)
    {
        var announcements = _context.Announcements
            .Where(a => a.ClassroomId == classroomId)
            .Select(a => new ClassroomDetail
            {
                Id = a.Id,
                ClassroomId = a.ClassroomId,
                Title = a.Title,
                PostedOn = a.PostedOn,
                Type = "Announcement",
                Description = a.Description,
                DueDate = null,
                Deadline = null
            });

        var assignments = _context.Assignments
            .Where(asg => asg.ClassroomId == classroomId)
            .Select(asg => new ClassroomDetail
            {
                Id = asg.Id,
                ClassroomId = asg.ClassroomId,
                Title = asg.Title,
                PostedOn = asg.PostedOn,
                Type = "Assignment",
                Description = asg.Description,
                DueDate = asg.DueDate,
                Deadline = null
            });

        var quizzes = _context.Quizzes
            .Where(q => q.ClassroomId == classroomId)
            .Select(q => new ClassroomDetail
            {
                Id = q.Id,
                ClassroomId = q.ClassroomId,
                Title = q.Title,
                PostedOn = q.PostedOn,
                Type = "Quiz",
                Description = null,
                DueDate = null,
                Deadline = q.Deadline
            });

        var combined = await announcements
            .Concat(assignments)
            .Concat(quizzes)
            .OrderByDescending(x => x.PostedOn)
            .ToListAsync();

        return Ok(combined);
    }

    // ✅ POST: Create an Announcement, Quiz, or Assignment
    [HttpPost]
    public async Task<IActionResult> CreateDetail([FromBody] CreateUpdateClassroomDetailDto input)
    {
        if (input == null || string.IsNullOrWhiteSpace(input.Type) || string.IsNullOrWhiteSpace(input.Title))
        {
            return BadRequest("Type and Title are required.");
        }

        var type = input.Type.Trim().ToLower();

        switch (type)
        {
            case "announcement":
                var announcement = new Announcement
                {
                    Id = Guid.NewGuid(),
                    ClassroomId = input.ClassroomId,
                    Title = input.Title,
                    Description = input.Description,
                    PostedOn = DateTime.UtcNow
                };
                _context.Announcements.Add(announcement);
                break;

            case "assignment":
                if (input.DueDate == null)
                    return BadRequest("DueDate is required for Assignment.");

                var assignment = new Assignment
                {
                    Id = Guid.NewGuid(),
                    ClassroomId = input.ClassroomId,
                    Title = input.Title,
                    Description = input.Description,
                    DueDate = input.DueDate.Value,
                    PostedOn = DateTime.UtcNow
                };
                _context.Assignments.Add(assignment);
                break;

            case "quiz":
                if (input.Deadline == null)
                    return BadRequest("Deadline is required for Quiz.");

                var quiz = new Quiz
                {
                    Id = Guid.NewGuid(),
                    ClassroomId = input.ClassroomId,
                    Title = input.Title,
                    PostedOn = DateTime.UtcNow,
                    Deadline = input.Deadline.Value
                };
                _context.Quizzes.Add(quiz);
                break;

            default:
                return BadRequest("Invalid Type. Must be 'Announcement', 'Assignment', or 'Quiz'.");
        }

        await _context.SaveChangesAsync();
        return Ok(new { message = $"{input.Type} created successfully." });
    }
}
