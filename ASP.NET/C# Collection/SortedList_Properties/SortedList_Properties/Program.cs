using System.Collections;
namespace SortedList_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList mySortedList = new SortedList();//alway we have pass same type of key
            mySortedList.Add(12, 4);
            mySortedList.Add(3, 44);
            mySortedList.Add(1, 34);
            mySortedList.Add(0, 94);

            mySortedList.Clear();

            mySortedList.Add("sd", 43);
            mySortedList.Add("fd", 47);
            mySortedList.Add("ad", 3);

            foreach (DictionaryEntry item in mySortedList)
            {
                Console.WriteLine($"Key:{item.Key}  Value:{item.Value}");
            }

            Console.WriteLine();
            var myList=mySortedList.Clone();

            foreach (DictionaryEntry item in (SortedList)myList)
            {
                Console.WriteLine($"Key:{item.Key}  Value:{item.Value}");
            }

            var isKey = mySortedList.ContainsKey("ad");
            var index = mySortedList.GetByIndex(1);
        }
    }
}
