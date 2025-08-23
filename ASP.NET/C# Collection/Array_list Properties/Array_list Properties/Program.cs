using System.Collections;
namespace Array_list_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            //that why it is not memmory friendly
            arrayList.Add(1);
            arrayList.Add(3);
            arrayList.Add(2);
            arrayList.Add(4);
            Console.WriteLine(arrayList.Capacity);
            arrayList.Add(1);
            Console.WriteLine(arrayList.Capacity);

            Console.WriteLine("size:"+arrayList.Count);
            Console.WriteLine("isFixedsize:" + arrayList.IsFixedSize);
            Console.WriteLine("IsReadOlny:" + arrayList.IsReadOnly);

            var arrayList1=ArrayList.FixedSize(arrayList);
            Console.WriteLine("arrayList1 isFixedsize:" + arrayList1.IsFixedSize);
            //we can not add or remove element in arraylist1 but can update
            arrayList1[0] = 4656;

            var arrayList2 = ArrayList.ReadOnly(arrayList);
            Console.WriteLine("arrayList2 isReadOnly:" + arrayList2.IsReadOnly);
            //we can not add or remove or update element in arraylist2

        }
    }
}
