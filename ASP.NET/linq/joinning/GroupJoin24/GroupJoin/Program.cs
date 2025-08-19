using System.Runtime.CompilerServices;

namespace GroupJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Catagory datasource
            var categories = new List<Catagory>
            {
                new Catagory { Id = 1, Name = "Science" },
                new Catagory { Id = 2, Name = "Arts" },
                new Catagory { Id = 3, Name = "Commerce" }
            };

            // Student datasource
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", CatagoryId = 1 },
                new Student { Id = 2, Name = "Bob", CatagoryId = 1 },
                new Student { Id = 3, Name = "Charlie", CatagoryId = 2 },
                new Student { Id = 4, Name = "David", CatagoryId = 3 },
                new Student { Id = 5, Name = "Eva", CatagoryId = 2 }
            };

            var ms=categories.GroupJoin(students,cat=>cat.Id,std=>std.CatagoryId,(cat,std)=>new { cat, std });
            


            foreach (var item in ms)
            {
                Console.WriteLine("Catagory Name=>" + item.cat.Name);
                foreach (var item2 in item.std)
                {
                    Console.WriteLine("StudentName=>"+item2.Name);
                }
            }

            var qs = (from cat in categories
                      join std in students
                      on cat.Id equals std.CatagoryId
                      into stdGroup
                      select new { cat, stdGroup }).ToList();

            foreach (var item in qs)
            {
                Console.WriteLine("Catagory Name=>" + item.cat.Name);
                foreach (var item2 in item.stdGroup)
                {
                    Console.WriteLine("StudentName=>" + item2.Name);
                }
            }
        }
    }
}
