namespace Projection_Operation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(1,"Riaz","riaz@gmail.com"),
                new Employee(2,"Rafi","rafi@gmail.com"),
                new Employee(3,"Roy","roy@gmail.com"),
                new Employee(4,"Sadik","sadik@gmail.com"),
                new Employee(5,"Mahir","mahir@gmail.com"),
            };

            var basicQuery=(from emp in employees
                           select emp).ToList();

            var basicPropQuery = (from emp in employees
                              select emp.Id+1).ToList();
            

            foreach (Employee emp in basicQuery)
            {
                Console.WriteLine(emp.Name+" "+emp.Email);
            }
            Console.WriteLine("----------------");

            var BasicMethod = employees.ToList();

            var BasicPropMethod = employees.Select(emp => emp.Id.ToString()).ToList();
           

            foreach (Employee emp in BasicMethod)
            {
                Console.WriteLine(emp.Name + " " + emp.Email);
            }

            var selectQuery=(from emp in employees
                            select new Employee()
                            {
                                Id = emp.Id,
                                Name = emp.Name,
                            }).ToList();
            

            foreach (var emp in selectQuery)
            {
                Console.WriteLine(emp.Id + " " + emp.Name);
            }

            var selectQuery1 = (from emp in employees
                               select new student()
                               {
                                   SId = emp.Id,
                                   SName = emp.Name,
                                   SEmail = emp.Email,
                               }).ToList();

            var selectQuery2 = (from emp in employees
                                select new 
                                {
                                    Cus_Id = emp.Id,
                                    Cus_Name = emp.Name,
                                    Cus_Email = emp.Email,
                                }).ToList();
            var MethodselectQuery = employees.Select(emp => new student()
            {
                SId = emp.Id,
                SName = emp.Name,
                SEmail = emp.Email,
            }).ToList();

            var MethodselectQuery1 = employees.Select(emp => new 
            {
                CId = emp.Id,
                CName = emp.Name,
                CEmail = emp.Email,
            }).ToList();

            var MethodselectQuery2 = employees.Select((emp,index) => new
            {
                Index = index,
                CId = emp.Id,
                CName = emp.Name,
                CEmail = emp.Email,
            }).ToList();

            foreach (var st in selectQuery1)
            {
                Console.WriteLine(st.SId + " " + st.SName+" "+st.SEmail);
            }

        }
    }
}
