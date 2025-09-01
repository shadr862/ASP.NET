using System.ComponentModel.DataAnnotations;

namespace ToDo_WebApi.ModelDto
{
    public class CreateUpdateToDo
    {
        [Required(ErrorMessage ="Name is Requied")]
        [StringLength(100,ErrorMessage ="Length should be less of equal to 100")]
        public string ToDoName { get; set; }
        public string ToDoDescription { get; set; }
    }
}
