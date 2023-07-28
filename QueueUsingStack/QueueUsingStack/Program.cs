using System;

namespace QueueUsingStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueUsingStacks<int> myQueue = new QueueUsingStacks<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);
            myQueue.PrintQueue();

            Console.WriteLine("Dequeue: " + myQueue.Dequeue()); // Output: Dequeue: 10
            Console.WriteLine("Peek: " + myQueue.Peek());       // Output: Peek: 20

            myQueue.Enqueue(40);
            Console.WriteLine("Count: " + myQueue.Count());    // Output: Count: 3

            while (!myQueue.IsEmpty())
            {
                Console.WriteLine("Dequeue: " + myQueue.Dequeue());
            }
        }
    }
}