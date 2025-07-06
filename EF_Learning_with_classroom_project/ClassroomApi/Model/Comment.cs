namespace ClassroomApi.Model
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid? AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public Guid? AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    }
}
