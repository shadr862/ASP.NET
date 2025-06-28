using ClassroomApi.Model;
using System.Text.Json.Serialization;

namespace ClassroomApi.ModelDto
{
    public class CreateUpdateQuizQuestionDto
    {
        public Guid QuizId { get; set; }
        public string QuestionType { get; set; } // e.g., "MultipleChoice", "TrueFalse", etc.
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
