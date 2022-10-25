using System;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RepeatRecursive("#",5));
            Console.WriteLine(string.Join(",",Change(15)));
            Console.WriteLine(QuickFib(45));
            int[] arr= { 3,4,1,2,7,8,9};
            BubleSort(arr);
            Console.WriteLine(string.Join(",", arr));
            int[] arr1 = { 3, 4, 1, 2, 7, 8, 9 };

            Sum(arr1,1,9);
            Console.WriteLine(arr);
        }
        public static string Repeat(string s, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result = result + s; // result(i)<-result (s,i-i)+s
            }
            return result;
        }
        public static string RepeatRecursive(string s, int n)
        {
            if (n <= 0)
            {
                return "";
            }

            Console.WriteLine($"Call for {n}");
            return RepeatRecursive(s, n - 1) + s;

        }
        /// napisz wersje rekurencyjna funkcji sumującej elementy tablicy od startu do endu
        public static int Sum(int[]arr ,int start, int left)
        {
            
            if (left == start)
            {
                return arr[left];
            }
            else
            {
                int pivot = (left + start) / 2;
                return Math.Max(Sum(arr, left, pivot), Sum(arr, pivot + 1, start));
            }
        }
        public static int[]Change(int amount)
        {
            int[] arr = new int[3];
            arr[2] = amount / 5;
            amount = amount - 5 * arr[2];
            arr[1] = amount / 2;
            amount = amount - 2 * arr[1];
            arr[0] = amount / 1;
            amount = amount - 1 * arr[0];
            return arr;


        }
        //zdefiniuj wydawanie reszty dla nominałow w tablicy
        // np. [1,2,5,10,20]
        public static int[] ChangeBis(int amounut, int[] nominals)
        {
            throw new NotImplementedException();
        }
        
        public static int Fib(int n)
        {
            if (n < 2)
            {
                return n;
            }
            return Fib(n - 2) + Fib(n - 1);
        }
        
        private static int FibMem(int n, int[] mem)
        {
            if (n < 2)
            {
                return n;
            }
            if (mem[n - 2] == 0)
            {
                mem[n - 2] = FibMem(n - 2, mem);
            }
            if (mem[n - 1] == 0)
            {
                mem[n - 1] = FibMem(n - 1, mem);
            }
            return mem[n - 2] + mem[n - 1];

        }
        public static int QuickFib(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return FibMem(n, new int[n]);
            
        }
        public static void BubleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j =   arr.Length-1;j>i;j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }
    }
}
