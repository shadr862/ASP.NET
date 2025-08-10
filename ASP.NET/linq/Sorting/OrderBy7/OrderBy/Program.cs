namespace OrderBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataSource=new List<int>() {11,26,3,4,56,16,74,18,9};

            var querySyntax=(from num in dataSource
                             where num>10
                             orderby num
                             select num).ToList();

            var methodSyntax=dataSource.Where(num=>num>20).OrderBy(num => num).ToList();


            var dataSource1 = new List<string>()
                              {
                                "Apple",
                                "Banana",
                                "Cherry",
                                "Date",
                                "Elderberry",
                                "Fig",
                                "Grape",
                                "Honeydew",
                                "Kiwi"
                             };

            var querySyntax1 = (from str in dataSource1
                               where str.Length>6
                               orderby str
                               select str).ToList();

            var methodSyntax1 = dataSource1.Where(str => str.Length > 3).OrderBy(str => str).ToList();


            var dataSource2 = new List<Employee>()
                                {
                                    new Employee { Id = 5, Name = "John Doe", Email = "john.doe@example.com" },
                                    new Employee { Id = 1, Name = "Jane Smith", Email = "jane.smith@example.com" },
                                    new Employee { Id = 3, Name = "Michael Johnson", Email = "michael.johnson@example.com" },
                                    new Employee { Id = 2, Name = "Emily Davis", Email = "emily.davis@example.com" },
                                    new Employee { Id = 4, Name = "William Brown", Email = "william.brown@example.com" }
                                };

            var querySyntax2 = (from emp in dataSource2
                                where emp.Id>3
                                orderby emp.Name
                                select emp).ToList();

            var methodSyntax2=dataSource2.Where(emp=>emp.Id>2).OrderBy(emp=>emp.Name).ToList();

            Console.ReadLine();
        }
    }
}
