namespace where_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var DataSource = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            var querySyntax=(from num in DataSource
                            where num<5 || num>9
                            select num).ToList();

            var methodSyntex = DataSource.Where(num => num < 6).ToList();



            var dataSource = new List<string>() { "Tom", "Harry", "Addam", "Riaz", "Rafi" };

            var querySyntax1= (from str in dataSource
                               where str=="Tom" || str.Length > 4
                               select str).ToList();

            var methodSyntax1=dataSource.Where(str=>str.Contains("Ad")).ToList();


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

            var  querySyntax2=(from std in DataSource1
                              where std.Programming.Count==3 && std.Id==3
                              select std).ToList();

            var methodSyntax2 = DataSource1.Where(std => std.Programming.Count == 0 || std.Name == "Riaz");

            Console.ReadLine();
        }
    }
}
