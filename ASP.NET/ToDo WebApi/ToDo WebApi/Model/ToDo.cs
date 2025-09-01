namespace ToDo_WebApi.Model
{
    public class ToDo
    {
        public Guid ToDoId { get; set; }
        public string ToDoName { get; set; }
        public string ToDoDescription { get; set; }

    }
}
/*
   Middleware are components that are used to handle http reaqests and responses in Asp.net.
   Http has request processing pipeline that has seris of middleware who can hanlde request or pass to next middleware,also use to handle exception,handling error etc
 */