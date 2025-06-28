namespace ClassroomApi.ModelDto
{
    public class CreateUpdateAssignmentDto
    {
        public Guid ClassroomId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
