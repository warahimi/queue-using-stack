using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStack
{
    class QueueUsingStacks<T>
    {
        private Stack<T> enqueueStack; // Stack used for enqueue operation (pushing elements into the queue)
        private Stack<T> dequeueStack; // Stack used for dequeue operation (popping elements from the front of the queue)

        public QueueUsingStacks()
        {
            enqueueStack = new Stack<T>(); // Initialize the enqueue stack
            dequeueStack = new Stack<T>(); // Initialize the dequeue stack
        }

        public void Enqueue(T item)
        {
            enqueueStack.Push(item); // Simply push the item onto the enqueue stack
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            // If the dequeue stack is empty, transfer elements from enqueueStack to dequeueStack
            if (dequeueStack.Count == 0)
            {
                // Transfer elements from enqueueStack to dequeueStack in reverse order (FIFO order)
                while (enqueueStack.Count > 0)
                {
                    dequeueStack.Push(enqueueStack.Pop());
                }
            }

            // Pop the top element from the dequeue stack, which corresponds to the oldest element in the queue
            return dequeueStack.Pop();
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            // If the dequeue stack is empty, transfer elements from enqueueStack to dequeueStack
            if (dequeueStack.Count == 0)
            {
                // Transfer elements from enqueueStack to dequeueStack in reverse order (FIFO order)
                while (enqueueStack.Count > 0)
                {
                    dequeueStack.Push(enqueueStack.Pop());
                }
            }

            // Return the top element from the dequeue stack without removing it, which corresponds to the oldest element in the queue
            return dequeueStack.Peek();
        }

        public bool IsEmpty()
        {
            return enqueueStack.Count == 0 && dequeueStack.Count == 0; // The queue is empty if both stacks are empty
        }

        public int Count()
        {
            return enqueueStack.Count + dequeueStack.Count; // The total count of elements in the queue is the sum of counts in both stacks
        }
        public void PrintQueue()
        {
            Console.WriteLine("Queue elements:");

            // Print elements in the enqueueStack (from bottom to top)
            foreach (T element in enqueueStack)
            {
                Console.Write(element + " ");
            }

            // Print elements in the dequeueStack (from top to bottom, as it represents the front of the queue)
            foreach (T element in dequeueStack.Reverse())
            {
                Console.Write(element + " ");
            }

            Console.WriteLine(); // Move to the next line after printing all elements
        }

    }

}
