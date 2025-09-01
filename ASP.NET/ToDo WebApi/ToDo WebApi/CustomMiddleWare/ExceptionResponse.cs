using System.Net;

namespace ToDo_WebApi.CustomMiddleWare
{
    public class ExceptionResponse
    {
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }

        public ExceptionResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
