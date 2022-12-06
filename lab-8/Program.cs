using System;
 
namespace lab8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Heap heap = new Heap();
            heap.Insert(6);
            heap.Insert(7);
            heap.Insert(8);
            heap.Insert(4);
            heap.Insert(2);
            heap.Insert(1);
            if (heap.Remove() == 8)
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
 
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(new IntDecsending());
            queue.Enqueue(6, 6);
            queue.Enqueue(7, 7);
            queue.Enqueue(8, 8);
            queue.Enqueue(4, 4);
            queue.Enqueue(2, 2);
            queue.Enqueue(1, 1);
            while (queue.Count > 0)
            {
                System.Console.WriteLine(queue.Dequeue());
            }
            //Zadanie 1
            PriorityQueue<string, int> queueNames = new PriorityQueue<string, int>();
            queueNames.Enqueue("Adam", 6);
            queueNames.Enqueue("Karol", 2);
            queueNames.Enqueue("Ewa", 9);
            while (queueNames.Count > 0)
            {
                System.Console.WriteLine(queueNames.Dequeue());
            }
            //Zadanie 2
            PriorityQueue<string, int> queueAlphabetNames = new PriorityQueue<string, int>();
            queueAlphabetNames.Enqueue("Adam", 6);
            queueAlphabetNames.Enqueue("Karol", 2);
            queueAlphabetNames.Enqueue("Ewa", 9);
            while (queueAlphabetNames.Count > 0)
            {
                System.Console.WriteLine(queueAlphabetNames.Dequeue());
            }
            //Utwórz kolejkę prioryteotwą łańcuchów o priorytetach
            //"Adam" 6
            //"Ewa" 9
            //"Karol" 2
            //Zadanie 2
            //Zdefiniuj kolejkę priorytetową obiektów klasy Student ,a  priorytetem w polu Ects,
            // im wyższy ECts tym wyższy priorytet
            //Zadanie 3
            //Kolejka łańcuchów z priorytetem leksykograficznym
            //najwyższym priorytet ma łańcuch pierwszy w porządku alfabetycznym
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Ects { get; set; }
    }
 
    class IntDecsending : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
 
 
 
    class Heap
    {
 
        private int[] heap = new int[100];
 
        private int last = -1;
 
        bool IsEmpty()
        {
            return last < 0;
        }
 
        bool IsFull()
        {
            return last >= heap.Length - 1;
        }
 
        public bool Insert(int value)
        {
            if (IsFull())
            {
                return false;
            }
 
            last++;
            heap[last] = value;
            RebuildUp(last);
            return true;
        }
 
        public int Remove()
        {
 
            int returnValue = heap[0];
            heap[0] = heap[last];
            last--;
            //TODO przebuduj drzewo w dół
            return returnValue;
 
        }
 
        void RebuildUp(int i)
        {
            int value = heap[i];
            while (i > 0)
            {
                int parentValue = heap[Parent(i)];
                if (parentValue < value)
                {
                    (heap[i], heap[Parent(i)]) = (heap[Parent(i)], heap[i]);
                    i = Parent(i);
                }
                else
                {
                    break;
                }
            }
        }
 
        int Parent(int i)
        {
            return (i - 1) / 2;
        }
        int Left(int i)
        {
            return 2 * i + 1;
        }
        int Right(int i)
        {
            return 2 * i + 2;
        }
 
 
    }
}