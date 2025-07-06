namespace ClassroomApi.Model
{
    public class ClassroomDetail
    {
        public Guid Id { get; set; }
        public Guid ClassroomId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; } // "Announcement", "Assignment", "Quiz"
        public DateTime PostedOn { get; set; }

        // Optional (type-specific)
        public string? Description { get; set; }     // Announcement, Assignment
        public DateTime? DueDate { get; set; }      // Assignment
        public DateTime? Deadline { get; set; }     // Quiz
    }

}
