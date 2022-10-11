using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 23, 1, 56, 345, 1, 5, 67, 11 };
            int index = FindTwoDigitalMin(arr1);
            if(index==7)
            {
                Console.WriteLine("Ok");

            }
            else
            {
                Console.WriteLine("Fail");
            }
            int[] arr2 = { };
            index = FindTwoDidgitalMin(arr2);
            if( index==-1)
            {
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            int[] arr3 = { 1, 3, 4, 123, 1234 };
            index = FindTwoDigitalMin(arr3);
            if(index == -1)
            {
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}
