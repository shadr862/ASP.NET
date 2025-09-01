using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ToDo_WebApi.Model;
using ToDo_WebApi.ModelDto;

namespace ToDo_WebApi.Interfaces
{
    public interface IToDoService
    {
        List<ToDo> GetAll();
        ToDo? GetById(Guid Id);
        ToDo? AddToDoItem([FromBody] CreateUpdateToDo ToDoDto);
        ToDo? UpdateTodoItem(Guid Id, [FromBody] CreateUpdateToDo ToDoDto);
        ToDo? PatchTodoItem(Guid Id, [FromBody] JsonPatchDocument<ToDo> PatchDoc);
        ToDo? DeleteTodoItem(Guid Id);
    }
}
