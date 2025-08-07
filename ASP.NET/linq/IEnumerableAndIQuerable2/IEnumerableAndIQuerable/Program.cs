namespace IEnumerableAndIQuerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 }; 

            IEnumerable<int> querySyntax=from obj in list
                                         where obj>1
                                         select obj;
            foreach (int item in querySyntax)
            {
                Console.WriteLine(item);
            }

            List<Employee> employeeList = new List<Employee>()
            {
                new Employee(1,"Riaz"),
                new Employee(2,"saad")
            };

            IEnumerable<Employee> query=from emp in employeeList
                                        where emp.Id == 1
                                        select emp;
            foreach (Employee emp in query)
            {
                Console.WriteLine(emp.Id+" "+emp.Name);
            }

            IQueryable<Employee> query1 = employeeList.AsQueryable().Where(e => e.Id > 1);

            foreach (Employee emp in query1)
            {
                Console.WriteLine(emp.Id + " " + emp.Name);
            }
        }
    }

    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
