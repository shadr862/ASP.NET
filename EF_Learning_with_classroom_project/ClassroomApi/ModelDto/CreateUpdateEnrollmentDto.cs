namespace ClassroomApi.ModelDto
{
    public class CreateUpdateEnrollmentDto
    {
        public Guid ClassroomId { get; set; }
        public Guid StudentId { get; set; }
    }
}
