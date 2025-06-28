namespace ClassroomApi.ModelDto
{
    public class CreateUpdateCommentDto
    {
        public Guid userId { get; set; }
        public Guid AssignmentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
