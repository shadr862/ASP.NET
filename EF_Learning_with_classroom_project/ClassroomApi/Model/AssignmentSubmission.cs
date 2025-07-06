using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class AssignmentSubmission
    {
        internal object fullName;

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AssignmentId { get; set; }
        [JsonIgnore]
        public Assignment Assignment { get; set; }

        public Guid StudentId { get; set; }
        [JsonIgnore]
        public User Student { get; set; }

        public string FilePath { get; set; }
        public double? Grade { get; set; }
    }

}
