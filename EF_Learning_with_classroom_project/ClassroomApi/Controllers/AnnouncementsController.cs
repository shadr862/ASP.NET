using ClassroomApi.Data;
using ClassroomApi.Model;
using ClassroomApi.ModelDto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/announcements")]
[EnableCors("Policy_2")]
public class AnnouncementsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AnnouncementsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnnouncements()
    {
        var announcements = await _context.Announcements
            .Include(a => a.Classroom)
            .ToListAsync();
        return Ok(announcements);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnnouncement(Guid id)
    {
        var announcement = await _context.Announcements
            .Include(a => a.Classroom)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (announcement == null)
        {
            return NotFound();
        }
        return Ok(announcement);
    }

    [HttpGet("classId/{id}")]
    public async Task<IActionResult> GetAnnouncementsByClassroomId(Guid id)
    {
        var announcements = await _context.Announcements
            .Where(a => a.ClassroomId == id)
            .Include(a => a.Classroom)
            .ToListAsync();
        if (announcements == null || !announcements.Any())
        {
            return NotFound($"No announcements found for ClassroomId: {id}");
        }
        return Ok(announcements);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnnouncement([FromBody] CreateUpdateAnnouncementDto announcement)
    {
        if (announcement == null || string.IsNullOrWhiteSpace(announcement.Title) || string.IsNullOrWhiteSpace(announcement.Description))
        {
            return BadRequest("Invalid announcement data.");
        }
        var classroom=new Announcement
        {
            Id = Guid.NewGuid(),
            ClassroomId = announcement.ClassroomId,
            Title = announcement.Title,
            Description = announcement.Description,
            PostedOn = DateTime.UtcNow
        };
        _context.Announcements.Add(classroom);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAnnouncement), new { id = classroom.Id }, classroom);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnnouncement(Guid id, [FromBody] CreateUpdateAnnouncementDto announcement)
    {
        if (announcement == null || string.IsNullOrWhiteSpace(announcement.Title) || string.IsNullOrWhiteSpace(announcement.Description))
        {
            return BadRequest("Invalid announcement data.");
        }
        var existingAnnouncement = await _context.Announcements.FindAsync(id);
        if (existingAnnouncement == null)
        {
            return NotFound();
        }
        existingAnnouncement.Title = announcement.Title;
        existingAnnouncement.Description = announcement.Description;
        existingAnnouncement.PostedOn = DateTime.UtcNow;
        _context.Announcements.Update(existingAnnouncement);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnnouncement(Guid id)
    {
        var announcement = await _context.Announcements.FindAsync(id);
        if (announcement == null)
        {
            return NotFound();
        }
        _context.Announcements.Remove(announcement);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
