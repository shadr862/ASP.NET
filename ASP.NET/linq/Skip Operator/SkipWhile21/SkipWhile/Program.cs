namespace SkipWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<string> list = new List<string>() { "Kim", "jhon", "Ms", "Adam", "Riaz" };

            var ms=numbers.SkipWhile(x=>x<6).ToList();
            var misedS=(from num in numbers select num).SkipWhile(x=>x<3).ToList();

            var ms1=list.SkipWhile(x=>x.Length<4).ToList();
            var ms2=list.SkipWhile((name,ind)=>name.Length>ind).ToList();

        }
    }
}
