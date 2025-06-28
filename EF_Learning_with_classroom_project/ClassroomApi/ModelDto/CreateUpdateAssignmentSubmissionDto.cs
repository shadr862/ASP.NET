namespace ClassroomApi.ModelDto
{
    public class CreateUpdateAssignmentSubmissionDto
    {
        public Guid StudentId { get; set; }
        public Guid AssignmentId { get; set; }
        public string FilePath { get; set; }
        public double? Grade { get; set; }
    }
}
