using ClassroomApi.Model;

namespace ClassroomApi.ModelDto
{
    public class CreateUpdateQuizSubmissionDto
    {
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public Guid StudentId { get; set; }
        public User Student { get; set; }

        public string AnswersJson { get; set; }
        public double Score { get; set; }
    }
}
