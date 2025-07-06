namespace ClassroomApi.ModelDto
{
    public class CreateUpdateAssignmentSubmissionDto
    {
        public Guid StudentId { get; set; }
        public Guid AssignmentId { get; set; }
    }
}
