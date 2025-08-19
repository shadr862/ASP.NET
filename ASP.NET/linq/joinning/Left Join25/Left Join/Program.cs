namespace Left_Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Address datasource
            var addresses = new List<Address>
            {
                new Address { Id = 1, AddressLine = "Dhaka" },
                new Address { Id = 2, AddressLine = "Chittagong" },
                new Address { Id = 3, AddressLine = "Khulna" }
            };

            // Student datasource
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", AddressId = 1 },
                new Student { Id = 2, Name = "Bob", AddressId = 2 },
                new Student { Id = 3, Name = "Charlie", AddressId = 5 }, // No matching address
                new Student { Id = 4, Name = "David", AddressId = 3 },
                new Student { Id = 5, Name = "Eva", AddressId = 10 }     // No matching address
            };

            var qs=(from std in students
                   join add in addresses on std.AddressId equals add.Id
                   into stdAddress
                   from studentAddress in stdAddress.DefaultIfEmpty()
                   select new {std,studentAddress}).ToList();

            var qs1 = (from std in students
                      join add in addresses on std.AddressId equals add.Id
                      into stdAddress
                      from studentAddress in stdAddress.DefaultIfEmpty()
                      select new {
                          studentName=std.Name,
                          studentAddress= studentAddress !=null ?studentAddress.AddressLine : "NULL",
                      }).ToList();

            var ms = students.GroupJoin(addresses, std => std.AddressId, add => add.Id, (std, add) => new { std, add })
                .SelectMany(x=>x.add.DefaultIfEmpty(),(studentData,AddressData)=> new { studentData.std, AddressData }).ToList();
        }
    }
}
