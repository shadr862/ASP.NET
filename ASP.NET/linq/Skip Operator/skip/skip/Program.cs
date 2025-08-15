namespace skip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<string> list = new List<string>() { "Kim", "jhon", "Mark", "Adam", "Riaz" };

            var ms=numbers.Skip(3).ToList();
            var ms1 = numbers.Where(x=>x>4).Skip(3).ToList();

            var misedS=(from str in list select str).Skip(2).ToList();
        }
    }
}
