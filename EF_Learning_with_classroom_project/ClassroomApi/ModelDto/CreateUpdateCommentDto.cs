namespace ClassroomApi.ModelDto
{
    public class CreateUpdateCommentDto
    {
        public Guid UserId { get; set; }
        public Guid? AssignmentId { get; set; }
        public Guid? AnnouncementId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
