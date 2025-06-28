using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class QuizQuestion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuizId { get; set; }
        [JsonIgnore]
        public Quiz Quiz { get; set; }
        public string QuestionType { get; set; } // e.g., "MultipleChoice", "TrueFalse", etc.
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
    }

}
