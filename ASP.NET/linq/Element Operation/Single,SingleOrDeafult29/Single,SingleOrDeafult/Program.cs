namespace Single_SingleOrDeafult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() {1};//always have to single element in database or you have to make single using condition

            var ms = numbers.Single();
            var ms1 = numbers.Where(x => x > 14).SingleOrDefault();

           
        }
    }
}
