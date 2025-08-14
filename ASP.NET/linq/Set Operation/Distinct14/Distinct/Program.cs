using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Distinct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 3, 4, 5, 5, 5, 1, 3, 2, 2, 4, 6, 7, 8, 9 };

            var ms=numbers.Distinct().ToList();

            var qs = (from num in numbers
                      select num).Distinct().ToList();

            List<Student> students = new List<Student>() {
                new Student() { Id=1,Name="Riaz" }, 
                new Student() { Id=2,Name="Rafi" },
                new Student() { Id=3,Name="Roy" },
                new Student() { Id=4,Name="Roy" },
                new Student() { Id=2,Name="Rafi" }};

            var ms1=students.Select(std=>std.Name).Distinct().ToList();
            var ms2 = students.Distinct().ToList();
            var ms3 = students.Distinct(new Compator()).ToList();


        }

       
    }

    class Compator : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (Object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                {
                return false;
            }

            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }

            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            if (Object.ReferenceEquals(obj, null))
            {
                return 0;
            }

            int IdhasCode = obj.Id.GetHashCode();
            int NamehasCode = obj.Name.GetHashCode();

            return IdhasCode ^ NamehasCode;
        }
    }
}
