using System.Collections;
namespace Queue_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3 ,4, 5, 6 };
            Queue myque = new Queue(arr);

            myque.Enqueue("Riaz");
            myque.Enqueue("Roy");
            myque.Enqueue("Rafi");
            myque.Enqueue("Sadik");
            myque.Enqueue(12);

            var p1=myque.Peek();
            var ele1=myque.Dequeue();

            var p2 = myque.Peek();
            var ele2=myque.Dequeue();

            var p3 = myque.Peek();
            var ele3=myque.Dequeue();
        }
    }
}
