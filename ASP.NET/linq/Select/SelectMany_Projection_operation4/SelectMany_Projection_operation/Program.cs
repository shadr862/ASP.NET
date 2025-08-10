using System.Runtime.InteropServices;

namespace SelectMany_Projection_operation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strList = new List<string>() { "Riaz", "Mehadi" };

            var methodResult = strList.SelectMany(ch => ch).ToList();

            var queryResult = (from str in strList
                               from ch in str
                               select ch).ToList();

            var DataSource = new List<Employee>()
            {
                new Employee{Id=1,Name="Riaz",Email="riaz@gmail.com", Programming=new List<string>(){"C++","C#","Java"} },
                new Employee{Id=2,Name="Rafi",Email="rafi@gmail.com", Programming=new List<string>(){"C","python","PHP"}},
                new Employee{Id=3,Name="Roy",Email="roy@gmail.com", Programming=new List<string>(){"Perl","Go","MVC"}},

            };

            var methodResult1 = DataSource.SelectMany(emp => emp.Programming).ToList();
            var queryResult1 = (from list in DataSource
                                from str in list.Programming
                                select str).ToList();

            var DataSource1 = new List<Student>()
            {
                new Student {Id=1,Name="Riaz",Email="riaz@gmail.com", Programming=
                new List<Tech>{
                    new Tech() { skill = "C++" },
                    new Tech() { skill = "C#" },
                    new Tech() { skill = "Java" }
                } 
                },
                 new Student {Id=2,Name="Rafi",Email="rafi@gmail.com",Programming=
                new List<Tech>{
                    new Tech() { skill = "C" },
                    new Tech() { skill = "python" },
                    new Tech() { skill = "MVC" }
                } 
                },
                new Student{Id=3,Name="Roy",Email="roy@gmail.com", Programming=
                new List<Tech>{
                    new Tech() { skill = "LINQ" },
                    new Tech() { skill = "Go" },
                    new Tech() { skill = "Perl" }
                }
                },
                new Student{Id=4,Name="Sadik",Email="sadik@gmail.com", Programming=new List<Tech>{ }},


            };

            var methodResult2 = DataSource1.SelectMany(emp => emp.Programming).ToList();
            var queryResult2 = (from list in DataSource1
                                from str in list.Programming
                                select str).ToList();


            Console.ReadLine();


        }
    }
    
     
}
