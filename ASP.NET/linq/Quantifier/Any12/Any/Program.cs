using System.Runtime.CompilerServices;

namespace Any
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

            var isAvail = list.Any();

            Student[] students = {
                new Student() { Name = "Riaz", Marks = 85 },
                new Student() { Name = "Rafi", Marks = 79}
            };

            var ms = students.Any(std => std.Marks > 70);
            var qs = (from std in students
                      select std).Any(std => std.Marks > 90);

            var DataSource = new List<student>()
            {
                new student
                {
                    Name = "Alice",
                    Subjects = new List<Subject>
                    {
                        new Subject { SubName = "Math", SubMarkes = 85 },
                        new Subject { SubName = "English", SubMarkes = 78 },
                        new Subject { SubName = "Science", SubMarkes = 92 }
                    }
                },
                new student
                {
                    Name = "Bob",
                    Subjects = new List<Subject>
                    {
                        new Subject { SubName = "Math", SubMarkes = 65 },
                        new Subject { SubName = "English", SubMarkes = 72 },
                        new Subject { SubName = "Science", SubMarkes = 80 }
                    }
                },
                new student
                {
                    Name = "Charlie",
                    Subjects = new List<Subject>
                    {
                        new Subject { SubName = "Math", SubMarkes = 90 },
                        new Subject { SubName = "English", SubMarkes = 88 },
                        new Subject { SubName = "Science", SubMarkes = 85 }
                    }
                }
            };

            var ms1=DataSource.Where(std=>std.Subjects.Any(sub=>sub.SubMarkes>85)).Select(std=>std.Name).ToList();

            var qs1=(from std in DataSource
                     where std.Subjects.Any(sub=>sub.SubMarkes>90)
                      select std.Name).ToList();
        }
    }
}
