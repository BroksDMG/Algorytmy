using System;

namespace task_1
{
    public class Task1
    {
        public static void Main(string[] args)
        {
            //task_1.1
            Console.WriteLine("////////////////task_1.1/////////////////");
            int[] arr = { 1, 2, 6 ,9 ,4, 3};
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0));          //false
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6));          //true
            Console.WriteLine(IsInArrayRecursive(new int[]{}, 0, arr.Length - 1, 5));          //false

            //task_1.2
            Console.WriteLine("////////////////task_1.2/////////////////");
            int[] arr1 = { 4, 5, 9, 4, 7, 2 };
            Console.WriteLine(SumMod3(arr));
            Console.WriteLine(SumMod3(arr1));

            //task_1.3
            Console.WriteLine("////////////////task_1.3/////////////////");
            Console.WriteLine(Factorial(4));

            //task_1.4
            Console.WriteLine("////////////////task_1.4/////////////////");
            int[] arr2 = { 1, 3, 2, 8, 2 };
            Console.WriteLine(IndexOfSumOfOthers(arr2));
        }
        public static bool IsInArray(int[] arr, int value)
        {
            return IsInArrayRecursive(arr, 0, arr.Length, value);
        }
        /**
         * REKURENCJA
         */
        //Zaimplementuj funkcję, która strategią dziel i zwyciężaj zwróci prawdę jeśli w tablicy
        //'arr' znajduje się wartość parametru 'value'.
        //Przykład
        //int[] arr = { 1, 2, 6 ,9 ,4, 3};
        //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0);          //false
        //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6);          //true
        //Console.WriteLine(IsInArrayRecursive(new int[]{}, 0, arr.Length - 1, 5);          //false
        public static bool IsInArrayRecursive(int[] arr, int left, int right, int value)
        {
            if (arr.Length == 0)
            {
                return false;
            }
            else if (left > right)
            {
                return false;
            }
            
            int middle = (left + right) / 2;
            if (arr[middle] == value){
                    return true;
                }
            else if (arr[middle] > value){
                    return IsInArrayRecursive(arr, left, middle - 1, value);
                }
            else{
                    return IsInArrayRecursive(arr, middle + 1, right, value);
                }
            
        }


        //Zdefiniuj funkcję rekurecyjną, która oblicza sumę elementów tablicy podzielnych przez 3
        //Nie można używać instrukcji iteracyjnych!!! Wartość funkcja dla pustej tablicy wynosi 0.
        //Można założyć, że tablica nie będzie równa null. Zdefiniuj funkcję pomocniczą która będzie wywoływana
        //rekurencyjnie wewnątrz SumMod3.
        public static long SumMod3(int[] arr)
        {
            
            return SumMod3Rec(arr, 0, arr.Length - 1);
        }
        private static long SumMod3Rec(int[] arr, int firstNum, int secondNum)
        {
            if (firstNum > secondNum)
            {
                return 0;
            }
            else
            {
                int middle = (firstNum + secondNum) / 2;
                if (arr[middle] % 3 == 0)
                {
                    return arr[middle] + SumMod3Rec(arr, firstNum, middle - 1) + SumMod3Rec(arr, middle + 1, secondNum);
                }
                else
                {
                    return SumMod3Rec(arr, firstNum, middle - 1) + SumMod3Rec(arr, middle + 1, secondNum);
                }
            }
        }

        //Zdefiniuj funkcję rekurencyjną, która oblicza silnię liczby.
        public static long Factorial(int n)
        {
            if (n <= 1)return 1;
            else return (n * Factorial(n - 1));
       
        }

        /**
         * ALGORYTMY I ZŁOŻONOŚĆ
         */
        //Zdefiniuj funkcję, która zwróci indeks liczby, która jest równa sumie pozostałych elementów tablicy
        //Przykład
        //int[] arr = {1, 3, 2, 8, 2};
        //int index = IndexOfSumOfOthers(arr);
        //funkcja w `index` powinna zwrócić 3, gdyż pod tym indeksem jest 8 równe sumie 1 + 3 + 2 + 2.
        //Jeśli w tablicy nie ma takiej liczby lub tablica jest pusta to funkcja pownna zwrócić -1.
        public static int IndexOfSumOfOthers(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == sum - arr[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
