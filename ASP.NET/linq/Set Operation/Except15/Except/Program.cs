using System.Diagnostics.CodeAnalysis;

namespace Except
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var DataSource1 = new List<string>() { "A", "B", "C", "D" };
            var DataSource2 = new List<string>() { "A", "B", "E", "F" };

            var ms= DataSource1.Except(DataSource2).ToList();

            var students1 = new List<Student>
            {
                new Student { Id = 1, Name = "Alice" },
                new Student { Id = 2, Name = "Bob" },
                new Student { Id = 3, Name = "Charlie" },
                new Student { Id = 4, Name = "David" },
                new Student { Id = 5, Name = "Eva" }
            };

          
            var students2 = new List<Student>
            {
                new Student { Id = 3, Name = "Charlie" }, // common
                new Student { Id = 4, Name = "David" },   // common
                new Student { Id = 6, Name = "Frank" },
                new Student { Id = 7, Name = "Grace" },
                new Student { Id = 8, Name = "Helen" }
            };

            var ms1=students1.Select(x=>x.Name).Except(students2.Select(x=>x.Name)).ToList();
            var ms2=students1.Select(x=>new { x.Id, x.Name }).Except(students2.Select(x=>new {x.Id,x.Name})).ToList();
            var ms3 = students1.Except(students2, new comparetor()).ToList();

            var qs1=(from std in students1
                     select std).Except(students2,new comparetor()).ToList();
        }
    }

    class comparetor : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
           if(x == null || y == null)
            {
                return false;
            }

           return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            if (object.ReferenceEquals(obj, null))
            {
                return 0;
            }

            int idHashCode=obj.Id.GetHashCode();
            int nameHashCode=obj.Name.GetHashCode();

            return idHashCode ^ nameHashCode;
        }
    }
}
