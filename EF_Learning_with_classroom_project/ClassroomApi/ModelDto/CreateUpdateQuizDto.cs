namespace ClassroomApi.ModelDto
{
    public class CreateUpdateQuizDto
    {
        public Guid ClassroomId { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }


    }
}
