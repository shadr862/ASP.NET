using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // "Admin", "Teacher", "Student"

        [JsonIgnore]
        public ICollection<Enrollment> Enrollments { get; set; }
        [JsonIgnore]
        public ICollection<Classroom> Classrooms { get; set; }
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }

}
