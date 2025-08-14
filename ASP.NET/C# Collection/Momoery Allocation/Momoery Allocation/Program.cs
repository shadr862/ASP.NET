namespace Momoery_Allocation
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            int[] myArray;//steack->all local variable and value type
            myArray=new int[3] {1,2,3};//heap->all instance and reference type 

            int[] myArray2 = myArray;

            myArray[0] = 200;
            myArray2[1] = 100;
            Console.WriteLine(myArray2[0]);
        }
    }
}
