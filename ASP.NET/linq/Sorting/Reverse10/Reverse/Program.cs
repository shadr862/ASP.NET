namespace Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] RollNum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            var Ms=RollNum.Reverse();

            var Qs=(from num in RollNum
                    select num).Reverse();

            var DataSource = new List<string>() { "Adam", "Kim", "Jhon", "Riaz", "Rafi" };

            DataSource.Reverse();

            var rev=DataSource.AsEnumerable().Reverse();

            var rev1=DataSource.AsQueryable().Reverse();    

            foreach (var item in DataSource)
            {
                Console.WriteLine(item);
            }
        }
    }
}
