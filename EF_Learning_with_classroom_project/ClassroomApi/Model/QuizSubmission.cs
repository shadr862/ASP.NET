namespace ClassroomApi.Model
{
    public class QuizSubmission
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public Guid StudentId { get; set; }
        public User Student { get; set; }

        public string AnswersJson { get; set; }
        public double Score { get; set; }
    }

}
