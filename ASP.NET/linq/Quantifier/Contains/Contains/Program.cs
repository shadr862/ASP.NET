using System.Diagnostics.CodeAnalysis;

namespace Contains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "Kim", "Jocob", "Simon", "Jhon" };

            var isExist = list.AsEnumerable().Contains("Kim");

            var QsIsExist = (from str in list
                             select str).Contains("Riaz");

            List<Student> students = new List<Student>() { 
                new Student(){Id=1,Name="Riaz" },
                new Student(){Id=2,Name="Roy" }

            };

            var comparer = new StuentComparator();
            var IsAvailable=students.AsEnumerable().Contains(new Student() { Id = 1, Name = "Riaz" }, comparer);

            var QsIsAvailable = (from std in students
                                 select std).Contains(new Student() { Id = 2, Name = "Roy" }, comparer);

        }

        class StuentComparator : IEqualityComparer<Student>
        {
            public bool Equals(Student? x, Student? y)
            {
                if(object.ReferenceEquals(x, y)) return true;
                if(object.ReferenceEquals(x, null) || object.ReferenceEquals(y,null))
                {
                    return false;
                }

                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode([DisallowNull] Student obj)
            {
                if(object.ReferenceEquals(obj,null))
                {
                    return 0;
                }

                int IdhasCode=obj.Id.GetHashCode();
                int NamehasCode=obj.Name.GetHashCode();

                return IdhasCode ^ NamehasCode;
            }
        }
    }
}
