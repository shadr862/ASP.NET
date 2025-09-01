using Entity_FrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
namespace Entity_FrameworkCore.Data
{
    public class AppDbContext:DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<EmployeeProject> employeeProjects { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
            ConnectionString = "Server=DESKTOP-JBRE4TR;Database=LearningEntityFramwork;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseLazyLoadingProxies().UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relationship details->https://learn.microsoft.com/en-us/ef/core/modeling/relationships

            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Manager>().Property(m => m.Man_FName).IsRequired();

            modelBuilder.Entity<Manager>()
                .HasMany(m => m.Employees)
                .WithOne(m => m.Manager)
                .HasForeignKey(m => m.ManagerId)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmployeeDetails)
                .WithOne(e => e.Employee)
                .HasForeignKey<EmployeeDetails>(e => e.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<EmployeeProject>().HasKey(x => new { x.EmployeeId, x.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.employeeProjects)
                .HasForeignKey(x => x.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(x=>x.Project)
                .WithMany(x=>x.employeeProjects)
                .HasForeignKey(x=>x.ProjectId);
        }

    }
}
