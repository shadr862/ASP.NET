namespace Array_Method_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 4, 5, 6, 7, 8, 9, 10 };
            var readOnlayArray=Array.AsReadOnly(numbers);

            Console.WriteLine(readOnlayArray[0]);
            numbers[0] = 100;
            Console.WriteLine(readOnlayArray[0]);

            var ind = Array.BinarySearch(numbers,5);
            var ind1 = Array.BinarySearch(numbers, 2,5,6);

            int[] numbers1 = { 1, 2, 4, 5, 6, 7, 8, 9, 10 };

            Array.Clear(numbers1,0,2);

            foreach(int i in numbers1)
                Console.WriteLine(i);

            int[] nums = new int[10] {1,1,1,1,1,1,1,1,1,1};

            Array.ConstrainedCopy(numbers1, 2, nums, 5, 3);

            foreach (int i in nums)
                Console.WriteLine(i);

        }
    }
}
