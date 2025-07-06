using ClassroomApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApi.Model;
using ClassroomApi.ModelDto;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult GetAllComments()
        {
            var comments = _context.Comments.ToList();
            return Ok(comments);
        }


        [HttpGet("{id}")]
        public IActionResult GetCommentById(Guid id)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpGet("assignment/{assignmentId}")]

        public IActionResult GetCommentsByAssignmentId(Guid assignmentId)
        {
            var comments = _context.Comments
                .Where(c => c.AssignmentId == assignmentId)
                .ToList();
            if (comments.Count == 0)
            {
                return NotFound();
            }
            return Ok(comments);
        }

        [HttpGet("announcement/{annoucementId}")]

        public IActionResult GetCommentsByAnnoucementId(Guid annoucementId)
        {
            var comments = _context.Comments
                .Where(c => c.AnnouncementId == annoucementId)
                .ToList();
            if (comments.Count == 0)
            {
                return NotFound();
            }
            return Ok(comments);
        }


        [HttpPost]
        public IActionResult CreateComment([FromBody] CreateUpdateCommentDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest("Comment data is null.");
            }
            var comment = new Comment
            {
                UserId = commentDto.UserId,
                AssignmentId = commentDto.AssignmentId,
                AnnouncementId = commentDto.AnnouncementId,
                Name = commentDto.Name,
                Content = commentDto.Content,
                CreatedAt = DateTime.UtcNow
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(Guid id, [FromBody] CreateUpdateCommentDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest("Comment data is null.");
            }
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            comment.UserId = commentDto.UserId;
            comment.AssignmentId = commentDto.AssignmentId;
            comment.AnnouncementId = commentDto.AnnouncementId;
            comment.Name = commentDto.Name;
            comment.Content = commentDto.Content;
            comment.CreatedAt = DateTime.UtcNow;
            _context.Comments.Update(comment);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(Guid id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
