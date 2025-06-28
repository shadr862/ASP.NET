using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class Classroom
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid TeacherId { get; set; }

        [JsonIgnore]
        public User Teacher { get; set; }

        [JsonIgnore]
        public ICollection<Enrollment> Enrollments { get; set; }
        [JsonIgnore]
        public ICollection<Quiz> Quizzes { get; set; }
        [JsonIgnore]
        public ICollection<Assignment> Assignments { get; set; }
    }

}
