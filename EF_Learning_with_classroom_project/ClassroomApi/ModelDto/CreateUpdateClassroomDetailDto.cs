namespace ClassroomApi.ModelDto
{
    public class CreateUpdateClassroomDetailDto
    {
        public Guid ClassroomId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public string? Description { get; set; }     // Announcement, Assignment
        public DateTime? DueDate { get; set; }      // Assignment
        public DateTime? Deadline { get; set; }     
    }
}
