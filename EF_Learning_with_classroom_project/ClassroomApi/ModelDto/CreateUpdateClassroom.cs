namespace ClassroomApi.ModelDto
{
    public class CreateUpdateClassroom
    {
        public string ClassName { get; set; }
        public string Description { get; set; }
        public Guid TeacherId { get; set; } // FK to User
    }
}
