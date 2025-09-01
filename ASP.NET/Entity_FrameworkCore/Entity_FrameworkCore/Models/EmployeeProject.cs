namespace Entity_FrameworkCore.Models
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }//Foreing key
        public virtual Employee Employee { get; set; }//Reference Navigation Propertity

        public int ProjectId { get; set; }//Foreing key
        public virtual Project Project { get; set; }//Reference Navigation Propertity

}
}
