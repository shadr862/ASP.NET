using System.Collections;
namespace Hash_table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable  table=new Hashtable();

            table.Add("name", "Riaz");
            table.Add(1, 111);
            table.Add(2, 131);
            table.Add(3, 115);

            //update
            table[1] = 55;
            //remove
            table.Remove(1);

            var IsExistKey=table.ContainsKey("name");
            var IsExistValue = table.ContainsValue(131);


            foreach (DictionaryEntry item in table)
            {
                Console.WriteLine($"Key={item.Key} Value={item.Value}");
            }

            
        }
    }
}
