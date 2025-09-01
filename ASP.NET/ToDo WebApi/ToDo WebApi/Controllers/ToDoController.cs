using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ToDo_WebApi.Data;
using ToDo_WebApi.Interfaces;
using ToDo_WebApi.Model;
using ToDo_WebApi.ModelDto;
using ToDo_WebApi.Services;

namespace ToDo_WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        /*
          Status code catagory:

          informational->100-199
          sucessful->200-299
          redirection->300-399
          client error->400-499
          server error->500-599
       */

        /*
         ----- property injection----

         [FromServices]->this formservice attrribute is important for the injection
         public IToDoService toDoService { get; set; }

        */
       
        private readonly IToDoService _ToDoService;
        public ToDoController(IToDoService ToDoService)//Constructor Injection
        {
            _ToDoService = ToDoService;
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IToDoService toDoService) //Method Injection
        { 
            var ToDoItems = toDoService.GetAll();
            if (!ToDoItems.Any())
            {
                return NotFound();//404
            }

            return Ok(ToDoItems);//200
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            var ToDoItem = _ToDoService.GetById(Id);
            if (ToDoItem == null)
            {
                return NotFound();
            }

            return Ok(ToDoItem);
        }

        [HttpPost]
        public IActionResult AddToDoItem([FromBody] CreateUpdateToDo ToDoDto)
        {
            if (ToDoDto == null)
            {
                return BadRequest();//400
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ToDoItem =_ToDoService.AddToDoItem(ToDoDto); 
            return CreatedAtAction(nameof(GetById), new { Id = ToDoItem.ToDoId }, ToDoItem);//201
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateTodoItem(Guid Id,[FromBody]CreateUpdateToDo ToDoDto)
        {
            if (ToDoDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _ToDoService.UpdateTodoItem(Id, ToDoDto);
            return CreatedAtAction(nameof(GetById), new {Id=Id},item);
            
        }

        [HttpPatch("{Id}")]
        public IActionResult PatchTodoItem(Guid Id, [FromBody] JsonPatchDocument<ToDo> PatchDoc)
        {
            /*
              install->JsonPatchDocument
              install->microsoft.aspnetcore.mvc.newtonsoftjson\8.0.17\
              add->builder.Services.AddControllers().AddNewtonsoftJson();
              [{
                "op": "replace",
                "path": "/toDoDescription",
                "value": "we have to install NewtonsoftJson for patch"
               },
               {
                "op": "replace",
                "path": "/toDoName",
                "value": "Learning Patch from basic"
               }]

            */

            if (PatchDoc == null)
            {
                return BadRequest();
            }

            var item = _ToDoService.PatchTodoItem(Id, PatchDoc);

            return CreatedAtAction(nameof(GetById), new { Id = Id }, item);

        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteTodoItem(Guid Id)
        {
            var existingItem = _ToDoService.DeleteTodoItem(Id);
            if (existingItem == null)
            {
                return NotFound();
            }
            
            return Ok(existingItem);
        }
    }
}
