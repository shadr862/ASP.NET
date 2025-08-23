using System.Collections;
namespace Hash_table_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();

            ht.Add("first", "first_val");
            ht.Add("second", "second_val");
            ht.Add("third", "third_val");
            ht.Add(1, "1st_val");
            ht.Add(2, "2nd_val");

            Console.WriteLine(ht.Count);
            Console.WriteLine(ht.IsFixedSize);
            Console.WriteLine(ht.IsReadOnly);

            var keys= ht.Keys;
            foreach (var items in keys)
            {
                Console.Write($"{items} ");
            }
            Console.WriteLine();

            ht.Remove("first");

            foreach (var items in keys)
            {
                Console.Write($"{items} ");
            }
            Console.WriteLine();

            var newHt=ht.Clone();

            //ht.Clear();
            //Console.WriteLine("ht size="+ht.Count);

            var isContain = ht.Contains(1);
            var isContainKey = ht.ContainsKey(46);
            var isConatinValue = ht.ContainsValue("first");


        }
    }
}
