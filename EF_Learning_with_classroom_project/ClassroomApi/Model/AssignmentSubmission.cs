namespace ClassroomApi.Model
{
    public class AssignmentSubmission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public Guid StudentId { get; set; }
        public User Student { get; set; }

        public string FilePath { get; set; }
        public double? Grade { get; set; }
    }

}
