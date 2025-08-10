namespace ofType_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataSource = new List<object>() { "Adam", "Harry", "Kim", "Jhon", 1, 2, 3, 4, 5, 6, 7 };

            var MethodSyntax=dataSource.OfType<string>().Where(str=>str.Length>3).ToList();
            var MethodSyntax1 = dataSource.OfType<int>().ToList();

            var QuerySyntex=(from x in dataSource
                              where x is string && x.ToString().Length>3
                              select x).ToList();
            var QuerySyntex1 = (from x in dataSource
                               where x is int
                               select x).ToList();

            Console.ReadLine();
        }
    }
}
