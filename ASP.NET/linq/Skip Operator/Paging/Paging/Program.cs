using System;
using System.Collections.Generic;
using System.Linq;

namespace Paging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int TotalPagePerView = 5;
            var employees = GetEmployees();
            int totalPages = (int)Math.Ceiling((double)employees.Count / TotalPagePerView);

            Console.WriteLine($"Total Employees: {employees.Count}");
            Console.WriteLine($"Total Pages: {totalPages}");

            while (true)
            {
                Console.Write("Enter the page number (or 0 to exit): ");
                if (int.TryParse(Console.ReadLine(), out int pageNumber))
                {
                    if (pageNumber == 0) break; // exit condition

                    if (pageNumber < 1 || pageNumber > totalPages)
                    {
                        Console.WriteLine($"Page number must be between 1 and {totalPages}");
                        continue;
                    }

                    var pageData = employees
                        .Skip((pageNumber - 1) * TotalPagePerView)
                        .Take(TotalPagePerView)
                        .ToList();

                    Console.WriteLine($"\n--- Page {pageNumber} ---");
                    foreach (var emp in pageData)
                    {
                        Console.WriteLine($"{emp.Id} - {emp.Name}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Enter a valid number.");
                }
            }
        }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Riaz" },
                new Employee() { Id = 2, Name = "Shad" },
                new Employee() { Id = 3, Name = "Hasan" },
                new Employee() { Id = 4, Name = "Mizan" },
                new Employee() { Id = 5, Name = "Farid" },
                new Employee() { Id = 6, Name = "Rahim" },
                new Employee() { Id = 7, Name = "Karim" },
                new Employee() { Id = 8, Name = "Sajid" },
                new Employee() { Id = 9, Name = "Masud" },
                new Employee() { Id = 10, Name = "Arif" },
                new Employee() { Id = 11, Name = "Nasir" },
                new Employee() { Id = 12, Name = "Mamun" },
                new Employee() { Id = 13, Name = "Sohan" },
                new Employee() { Id = 14, Name = "Tanvir" },
                new Employee() { Id = 15, Name = "Rakib" },
                new Employee() { Id = 16, Name = "Nadim" },
                new Employee() { Id = 17, Name = "Shuvo" },
                new Employee() { Id = 18, Name = "Imran" },
                new Employee() { Id = 19, Name = "Asif" },
                new Employee() { Id = 20, Name = "Parvez" },
                new Employee() { Id = 21, Name = "Shamim" },
                new Employee() { Id = 22, Name = "Akash" },
                new Employee() { Id = 23, Name = "Nafis" },
                new Employee() { Id = 24, Name = "Omar" },
                new Employee() { Id = 25, Name = "Ehsan" },
                new Employee() { Id = 26, Name = "Bashir" },
                new Employee() { Id = 27, Name = "Jahid" },
                new Employee() { Id = 28, Name = "Fahim" },
                new Employee() { Id = 29, Name = "Zahid" },
                new Employee() { Id = 30, Name = "Mahin" },
            };
        }
    }

   
}
