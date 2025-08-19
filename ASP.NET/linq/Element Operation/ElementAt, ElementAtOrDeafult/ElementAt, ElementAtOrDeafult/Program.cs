namespace ElementAt__ElementAtOrDeafult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9,10};
            var ms=numbers.Where(num=>num>3).ElementAt(5);// if i put out of index range give null exception
            var ms1 = numbers.ElementAtOrDefault(10);//if i put out of index range give defalt value 0

            List<string> strings = new List<string>() { "a", "b", "c" };

            var mixedS = (from str in strings select str).ElementAt(0);
        }
    }
}
