namespace Entity_FrameworkCore.Models
{
    public class EmployeeDetails
    {
        public int Id { get; set; }//Primary Key
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int EmployeeId { get; set; }//Foreing key
        public virtual Employee Employee { get; set; }//Reference Navigation Propertity
    }
}
