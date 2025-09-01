using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ToDo_WebApi.Data;
using ToDo_WebApi.Interfaces;
using ToDo_WebApi.Model;
using ToDo_WebApi.ModelDto;

namespace ToDo_WebApi.Services
{
    public class ToDoService:IToDoService
    {
        private readonly AppDbContext _context;
        public ToDoService(AppDbContext context)
        {
            _context = context;
        }

        public ToDo AddToDoItem([FromBody] CreateUpdateToDo ToDoDto)
        {
            var ToDoItem = new ToDo
            {
                ToDoName = ToDoDto.ToDoName,
                ToDoDescription = ToDoDto.ToDoDescription
            };

            _context.ToDos.Add(ToDoItem);
            _context.SaveChanges();

            return ToDoItem;
        }

        public ToDo? DeleteTodoItem(Guid Id)
        {
            var existingItem = _context.ToDos.FirstOrDefault(x => x.ToDoId == Id);
            if (existingItem == null)
            {
               return null;
            }
            _context.ToDos.Remove(existingItem);
            _context.SaveChanges();

            return existingItem;
        }

        public List<ToDo> GetAll()
        {
            var TodoItems= _context.ToDos.ToList();
            return TodoItems;
        }

        public ToDo? GetById(Guid Id)
        {
            var ToDoItem = _context.ToDos.FirstOrDefault(t => t.ToDoId == Id);
            if (ToDoItem == null)
            {
                return null;
            }

            return ToDoItem;
        }

        public ToDo? PatchTodoItem(Guid Id, [FromBody] JsonPatchDocument<ToDo> PatchDoc)
        {
            var item = _context.ToDos.FirstOrDefault(x => x.ToDoId == Id);
            if (item == null)
            {
                return null;
            }

            PatchDoc.ApplyTo(item);
            _context.SaveChanges();

            return item;
        }

        public ToDo? UpdateTodoItem(Guid Id, [FromBody] CreateUpdateToDo ToDoDto)
        {
            var item = _context.ToDos.FirstOrDefault(x => x.ToDoId == Id);
            if (item == null)
            {
                return null;
            }
            item.ToDoName = ToDoDto.ToDoName;
            item.ToDoDescription = ToDoDto.ToDoDescription;

            _context.SaveChanges();

            return item;

        }
    }
}
