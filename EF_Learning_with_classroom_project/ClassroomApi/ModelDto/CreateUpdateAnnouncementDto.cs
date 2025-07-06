using ClassroomApi.Model;
using System.Text.Json.Serialization;

namespace ClassroomApi.ModelDto
{
    public class CreateUpdateAnnouncementDto
    {
        public Guid ClassroomId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
 
    }
}
