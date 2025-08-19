using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inner_join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", AddressId = 1 },
                new Student { Id = 2, Name = "Bob", AddressId = 2 },
                new Student { Id = 3, Name = "Charlie", AddressId = 3 },
                new Student { Id = 4, Name = "David", AddressId = 4 },
                new Student { Id = 5, Name = "Eve", AddressId = 5 }
            };

            var addresses = new List<Address>
            {
                new Address { Id = 1, AddressLine = "Dhaka" },
                new Address { Id = 2, AddressLine = "Chittagong" },
                new Address { Id = 3, AddressLine = "Khulna" },
                new Address { Id = 6, AddressLine = "Sylhet" } 
            };

            var marks = new List<Mark>
            {
                new Mark { Std_Id = 1, mark = 85 },
                new Mark { Std_Id = 2, mark = 90 },
                new Mark { Std_Id = 3, mark = 78 },
                new Mark { Std_Id = 6, mark = 88 } // no matching student
            };

            var ms=students.Join(addresses,std=>std.AddressId,add=>add.Id,(std,add)=>new {
                Id=std.Id,
                Name=std.Name,
                AddressLine=add.AddressLine
              }).ToList();

            var ms1 = students.Join(addresses,
                std => std.AddressId, add => add.Id, (std, add) => new {std,add})
                .Join(marks,SA=>SA.std.Id,m=>m.Std_Id,(SA,m)=>new {SA,m})
                .Select(x=>new
                {
                    Id=x.SA.std.Id,
                    Name=x.SA.std.Name,
                    AddressLine=x.SA.add.AddressLine,
                    mark=x.m.mark
                }).ToList();

            var qs = (from std in students
                     join add in addresses
                     on std.AddressId equals add.Id
                     select new
                     {
                         Id = std.Id,
                         Name = std.Name,
                         AddressLine = add.AddressLine
                     }).ToList();

            var qs1 = (from std in students
                      join add in addresses
                      on std.AddressId equals add.Id
                      join mark in marks
                      on std.Id equals mark.Std_Id
                      select new
                      {
                          Id = std.Id,
                          Name = std.Name,
                          AddressLine = add.AddressLine,
                          mark=mark.mark
                      }).ToList();
        }
    }
}
