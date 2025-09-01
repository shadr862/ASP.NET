using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entity_FrameworkCore.Models
{
    [Table("AllManagers")]
    public class Manager
    {
        
        public int ManagerId { get; set; }
        [Column("ManagerFirstName")]
        [Required]
        public string Man_FName { get; set; }
        public string Man_LName { get; set; }
        [NotMapped]
        public int MyProperty { get; set; }
        [JsonIgnore]
        //one to many relationship to Employee
        public virtual ICollection<Employee> Employees { get; set; }//collection navigation property to represent the employees managed by manager
    }
}
