using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string expresstiom = "2 5 + 7 * qrt";
            foreach (string token in expresstiom.Split(" "))
            {
                switch (token)
                {
                    case "qrt":
                        if (stack.Count >= 1)
                        {
                            int a = stack.Pop();
                            stack.Push(a*a);
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }

                        break;
                    case "+":
                        if(stack.Count>=2){
                            int a = stack.Pop();
                            int b = stack.Pop();
                            stack.Push(a + b);
                        }else
                        {
                            throw new InvalidOperationException();
                        }

                        break;
                    case "-":
                        if (stack.Count >= 2)
                        {
                            int a = stack.Pop();
                            int b = stack.Pop();
                            stack.Push(b - a);
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                        break;
                    case "*":
                        if (stack.Count >= 2)
                        {
                            int a = stack.Pop();
                            int b = stack.Pop();
                            stack.Push(a * b);
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                        break;
                    case "/":
                        if (stack.Count >= 2)
                        {
                            int a = stack.Pop();
                            int b = stack.Pop();
                            stack.Push(b/a);
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                        break;
                    default:
                        if(int.TryParse(token, out int vale))
                        {
                            stack.Push(vale);
                        }else
                        {
                            throw new InvalidOperationException();
                        }
                        break;
                }
            }
            if (stack.Count == 1)
            {
                Console.WriteLine(stack.Pop());
            }
            else
            {
                Console.WriteLine("Błąd składniowy wyrażenia");
            }
        }
        static void StackTest()
        {
            LinkedStack<string> stack = new LinkedStack<string>();
            Console.WriteLine(stack.Count == 0);
            stack.Push("Adam");
            stack.Push("Ewa");
            stack.Push("Karol");
            foreach (string name in stack)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(stack.Pop() == "Karol");
            Console.WriteLine(stack.Count == 2);
        }
        static void QueueTest()
        {
            LinkedQueue<int> ints = new LinkedQueue<int>();
            ints.Enqueue(4);
            ints.Enqueue(3);
            ints.Enqueue(7);
            Console.WriteLine(ints.Count==3);
            Console.WriteLine(ints.Dequeue()==4);
            Console.WriteLine(ints.Count == 2);

        }

    }
    public class LinkedQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;
        public int Count { get { return count; } }
        public void Enqueue(T value)
        {
            if (IsEmpty())
            {
                head = new Node<T>() { Value = value };
                tail = head;
            }
            else
            {
                var node = new Node<T>() { Value = value };
                tail.Next = node;
                tail = node;
            }
            count++;
        }
        public T Dequeue()
        {
                if (!IsEmpty())
                {
                    T result = head.Value;
                    head = head.Next;
                    count--;
                    if (IsEmpty()) { tail = null; }
                    return result;
                }
                else
                {
                    throw new InvalidOperationException();
                }
        }
        public bool IsEmpty()
        {
            return head == null;
        }
    }

    internal class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
    public class LinkedStack<T>:IEnumerable<T>
    {
        private Node<T> head;
        private int count;
        public void Push(T item)
        {
            if (IsEmpty())
            {
                head = new Node<T>() { Value = item };
            }
            else
            {
                var node =new Node<T>() { Value = item };
                node.Next = head;
                head = node;
            }
                count++;
        }
        public T Pop()
        {
            if (!IsEmpty())
            {
                T result = head.Value;
                head = head.Next;
                count--;
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public int Count { get { return count;} }
        public bool IsEmpty()
        {
            return head == null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = head;
            while (node != null)
            {
                T r = node.Value;
                node = node.Next;
                yield return r;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
