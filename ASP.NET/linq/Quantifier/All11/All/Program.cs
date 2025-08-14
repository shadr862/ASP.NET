using System.Xml.Linq;

namespace All
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = {
                new Student() { Name="Riaz",marks=95},
                new Student() { Name = "Rafi", marks = 87 },
                new Student() { Name = "Roy", marks = 81 }
            };

            var Ms = students.All(std => std.marks > 80);
            var Ms1 = students.All(std => std.marks > 90);

            var Qs = (from std in students
                      select std).All(x => x.marks > 70);
            var Qs1 = (from std in students
                       select std).All(x => x.marks > 86);


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

            var Ms2=DataSource.Where(std=>std.Subjects.All(x=>x.SubMarkes>80)).Select(std=>std).ToList();

            var Qs2 = (from std in DataSource
                      where std.Subjects.All(x => x.SubMarkes > 75)
                      select std).ToList();

        }
    }
}
