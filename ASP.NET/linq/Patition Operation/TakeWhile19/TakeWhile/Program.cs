namespace TakeWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] numbers1 = { 1, 2, 6, 7, 8, 9, 10, 3, 4, 5 };
            //When conditon get failed ,it will stop fetching data.

            var ms = numbers.TakeWhile(x=>x<7).ToList();
            var ms1 = numbers1.TakeWhile(x => x < 7).ToList();
            var qs = (from num in numbers1
                      select num).TakeWhile(x => x < 7).ToList();

            var Dataset = new List<string>() { "kim", "Jhon", "Mark", "Viv", "Richard" };

            var qs1 = (from str in Dataset
                      select str).TakeWhile((name, ind) => name.Length > ind).ToList();

            var ms2=Dataset.TakeWhile((name,ind)=>name.Length>ind).ToList();
        }
    }
}
