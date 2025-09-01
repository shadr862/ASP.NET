using Microsoft.EntityFrameworkCore;
using ToDo_WebApi.CustomMiddleWare;
using ToDo_WebApi.Data;
using ToDo_WebApi.Interfaces;
using ToDo_WebApi.Services;
namespace ToDo_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Service for Denpendency Injection.
            //AddSingleton->Services are created Once and shared throughout the aplication life time.
            //AddTransient->Services are created for every request even in from same http request or same url
            //AddScoped->Services are created Once per request means for different http or dfferent 
            builder.Services.AddScoped<IToDoService, ToDoService>();

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Microsoft.AspNetCore.Mvc.Newtonsoftjoson for patch
            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<LoggingMiddleWare>();//custom middleware

            app.UseStaticFiles();//terminal middleware

            app.UseHttpsRedirection();//non-terminal middleware

            app.UseAuthorization();//non-terminal middleware


            app.MapControllers();

            app.Run();
        }
    }
}
