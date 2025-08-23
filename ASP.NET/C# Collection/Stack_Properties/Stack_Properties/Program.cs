using System.Collections;
namespace Stack_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack myStack= new Stack();

            myStack.Push("First");
            myStack.Push("Second");

            var peek=myStack.Peek();
            var p = myStack.Pop();

            myStack.Clear();
        }
    }
}
