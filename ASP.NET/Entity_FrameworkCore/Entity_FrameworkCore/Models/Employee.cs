using System.ComponentModel.DataAnnotations;

namespace Entity_FrameworkCore.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Emp_FName { get; set; }
        public string Emp_LName { get; set; }
        public int Emp_Salary { get; set; }

        //one to one Relationship with Employee Details
        public virtual EmployeeDetails EmployeeDetails { get; set; }//Reference Navigation Propertity to dependent

        //one to many Relationship to Manager
        public int ManagerId { get; set; }//Foreing Key
        public virtual  Manager Manager { get; set; }//Navigation property to represent manager

        //many to many
        public virtual ICollection<EmployeeProject> employeeProjects { get; set; }//Collection Nevigation properties
    }
}
