using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class Announcement
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClassroomId { get; set; }
        [JsonIgnore]
        public Classroom Classroom { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}
