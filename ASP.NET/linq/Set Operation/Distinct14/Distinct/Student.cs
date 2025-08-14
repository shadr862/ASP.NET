using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distinct
{
    internal class Student:IEquatable<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(Student? other)
        {
            if(object.ReferenceEquals(other,null))
            { 
                return false; 
            }
            if(object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Id.Equals(other.Id) && Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            int IdhasCode= Id.GetHashCode();
            int NamehasCode= Name.GetHashCode();

            return IdhasCode ^ NamehasCode;
        }
    }
}
