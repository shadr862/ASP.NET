using Microsoft.EntityFrameworkCore;
using ToDo_WebApi.Model;
namespace ToDo_WebApi.Data
{
    public class AppDbContext:DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ConnectionString = "Server=DESKTOP-JBRE4TR;Database=LearningWebApi;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
