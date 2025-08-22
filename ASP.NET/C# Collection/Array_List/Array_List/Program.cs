using System.Collections;

namespace Array_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //we should not use ArrayList,we should use List<T> because it is more memory friendly
            ArrayList myArrayList = new ArrayList() { 1, 2, 3,"Riaz",'r',true,4.5};
            myArrayList.Add(7);
            int[] arry = { 5, 6, 79};
            myArrayList.AddRange(arry);
            myArrayList[0] = 11;

            foreach (var item in myArrayList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
