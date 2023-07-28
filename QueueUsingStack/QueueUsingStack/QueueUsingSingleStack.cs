using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStack
{
    class QueueUsingSingleStack<T>
    {
        private Stack<T> stack;

        public QueueUsingSingleStack()
        {
            stack = new Stack<T>();
        }

        public void Enqueue(T item)
        {
            stack.Push(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            // Base case: If the stack contains only one element, it is the oldest element in the queue
            if (stack.Count == 1)
                return stack.Pop();

            // Recursive case: Pop an element from the stack and recursively call Dequeue
            T temp = stack.Pop();
            T dequeuedItem = Dequeue();

            // Push the temporarily popped element back to the stack after recursion
            stack.Push(temp);

            return dequeuedItem;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            // Base case: If the stack contains only one element, it is the oldest element in the queue
            if (stack.Count == 1)
                return stack.Peek();

            // Recursive case: Pop an element from the stack and recursively call Peek
            T temp = stack.Pop();
            T frontItem = Peek();

            // Push the temporarily popped element back to the stack after recursion
            stack.Push(temp);

            return frontItem;
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public int Count()
        {
            return stack.Count;
        }
        public void PrintQueue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");
            foreach(T item in stack.Reverse())
            {
                Console.Write(item + " ");
            }
        }
    }
}
