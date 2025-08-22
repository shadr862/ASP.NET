namespace Last_LastOrDeafult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var ms = numbers.Where(x => x > 7).Last();
            var ms1 = numbers.Where(x => x > 14).LastOrDefault();

            var mixedS=(from num in numbers
                        where num>10
                        select num).LastOrDefault();
        }
    }
}
