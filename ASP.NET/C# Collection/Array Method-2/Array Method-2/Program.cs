namespace Array_Method_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
            var arr2 = Array.ConvertAll(arr1, new Converter<int, string>(converter));

            var arr3 = new int[10];
            Array.Copy(arr1, arr3, 5);

            var arr4=new int[10];
            Array.Copy(arr1,2,arr4,4,5);

            var arr5 = Array.CreateInstance(typeof(string), 7);
            var arr6 = Array.CreateInstance(typeof(int), 3,3);
            var arr7 = Array.CreateInstance(typeof(int), 3, 3, 3);

            var arr8=Array.Empty<int>();

            List<int> list = new List<int>() { 1, 2, 3, 54, 5, 6 };
            arr8=list.ToArray();

        }

        public static string converter(int n)
        {
            return n.ToString();
        }
    }
}
