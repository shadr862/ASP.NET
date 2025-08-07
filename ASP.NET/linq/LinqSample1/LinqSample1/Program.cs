namespace LinqSample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 6, 7, 8, 9 };
            var querySyntax = from obj in list
                              where obj > 2
                              select obj;
            foreach (var item in querySyntax)
            { 
                 Console.WriteLine(item); 
            }

            Console.WriteLine("-----------------------");
            var methodSyntax = list.Where(obj => obj > 2);

            foreach (var item in methodSyntax)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("-----------------------");
            var mixedyntax = (from obj in list
                              select obj).Max();

            Console.WriteLine("max value: "+mixedyntax);
            

        }
    }
}
