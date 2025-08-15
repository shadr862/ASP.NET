namespace Take
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            var ms = numbers.Where(x=>x>3).Take(5).ToArray();
            var ms1 = numbers.Take(5).Where(x => x > 3).ToArray();

            var mixedS=(from num in numbers
                        where num>4
                        select num).Take(4).ToList();
            var mixedS1 = (from num in numbers
                          select num).Take(4).Where(x => x > 3).ToList();
        }
    }
}
