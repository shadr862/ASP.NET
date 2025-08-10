namespace ThenBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
                {
                    new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@company.com" },
                    new Employee { Id = 2, FirstName = "Jhon", LastName = "Smith", Email = "jane.smith@company.com" },
                    new Employee { Id = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@company.com" },
                    new Employee { Id = 4, FirstName = "Emily", LastName = "Davis", Email = "emily.davis@company.com" },
                    new Employee { Id = 5, FirstName = "Michael", LastName = "Brown", Email = "william.brown@company.com" }
                };

            var ms=employees.OrderByDescending(emp=>emp.FirstName).ThenByDescending(emp=>emp.LastName).ToList();
            var ms1 = employees.OrderBy(emp => emp.FirstName).ThenBy(emp => emp.LastName).ToList();
            var ms2 = employees.OrderBy(emp => emp.FirstName).ThenByDescending(emp => emp.LastName).ToList();

            var qs=(from emp in employees
                   orderby emp.FirstName descending,emp.LastName ascending
                   select emp).ToList();


            Console.ReadLine();
        }
    }
}
