using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class Enrollment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClassroomId { get; set; }
        [JsonIgnore]
        public Classroom Classroom { get; set; }
        public Guid StudentId { get; set; }
        [JsonIgnore]
        public User Student { get; set; }
    }

}
