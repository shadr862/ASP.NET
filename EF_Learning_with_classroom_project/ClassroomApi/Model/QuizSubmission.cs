using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class QuizSubmission
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid QuizId { get; set; }
        [JsonIgnore]
        public Quiz Quiz { get; set; }

        public Guid StudentId { get; set; }
        [JsonIgnore]
        public User Student { get; set; }

        public string AnswersJson { get; set; }
        public double Score { get; set; }
    }

}
