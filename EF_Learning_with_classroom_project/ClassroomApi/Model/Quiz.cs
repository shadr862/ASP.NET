using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class Quiz
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public DateTime Deadline { get; set; }

        public Guid ClassroomId { get; set; }
        [JsonIgnore]
        public Classroom Classroom { get; set; }
        [JsonIgnore]
        public ICollection<QuizQuestion> Questions { get; set; }
    }

}
