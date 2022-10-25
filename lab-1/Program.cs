using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 23, 1, 56, 345, 1, 5, 67, 11 };
            int index = FindTwoDigitalMin(arr1);

            if (index == 7)
            {
                Console.WriteLine("Ok");

            }
            else
            {
                Console.WriteLine("Fail");
            }
            //int[] arr2 = { };
            //index = FindTwoDigitalMin(arr2);
            //if (index == -1)
            //{
            //    Console.WriteLine("Ok");
            //}
            //else
            //{
            //    Console.WriteLine("Fail");
            //}
            //int[] arr3 = { 1, 3, 4, 123, 1234 };
            //index = FindTwoDigitalMin(arr3);
            //if(index == -1)
            //{
            //    Console.WriteLine("Ok");
            //}
            //else
            //{
            //    Console.WriteLine("Fail");
            //}
        }
        ////<summary>
        ///Funkcja szuka idneksu najmniejszej liczbt dwucyfrowej
        ///</summary>
        ///<param name"arr">tablica liczb dodatnich</param>
        ///<returns>indeks znalezionej liczby lub -1, gdy brak takiej liczby</return>
        public static int FindTwoDigitalMin(int[] arr)
        {
            Array.Sort(arr);
            
            int  min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (min < 10)
                {
                    arr[i]++;
                }
                else if (min > arr[i]&&min>10)
                {
                    if (min >= 10)
                    {
                        min = arr[i];
                    }
                    
                   
                    
                }
            }

            if (min >= 10) return min;
            else if (min < 10) {
                Console.WriteLine(min);
                Console.WriteLine("to nie dwucyfrowa");
                    return -1; 
            }
            else
            {
                Console.WriteLine("nie ma");
                return -1;
            }
        }
    }

    
}
