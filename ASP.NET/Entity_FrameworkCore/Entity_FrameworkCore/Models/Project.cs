namespace Entity_FrameworkCore.Models
{
    public class Project
    {
        public int ProjectId { get; set; }//primary key
        public string ProjectName { get; set; }

        //many to many
        public virtual ICollection<EmployeeProject> employeeProjects { get; set; }//Collection Nevigation properties
    }
}
