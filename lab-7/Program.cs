//skrzeczowski jakub
using System;
using System.Collections.Generic;


public class Task5
{
    public static void Main(string[] args)
    {
        StringHexPositionSort s = new StringHexPositionSort();
        string[] arr = { "AF3", "120", "236", "11A", "23", "5", "FFFFF" };
        try
        {
            s.Sort(arr, 5);
            if (
                   arr[0] == "5"
                && arr[1] == "23"
                && arr[2] == "11A"
                && arr[3] == "120"
                && arr[4] == "236"
                && arr[5] == "AF3"
               )
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }
        catch
        {
            Console.WriteLine("Test failed");
        }
    }
    //Cwiczenie 1
    //Zaimplementuj klasę do sortowania pozycyjnego liczb szesnastkowych zapisanych w łańcuchach 
    //Przykładowa tablica do posortowania
    //string[] HexNumbers = {"AF3", "12D", "236", "120", "1"};
    //tablica po sortowaniu
    //{"1", "120", "12D", "236", "AF3"}
    //Można założyć, że
    //- w tablicy są poprawne łańcuchy z liczbami szesastkowymi
    //- łańcuchy mają różną długość 
    //Możesz wzorować się na gotowym algorytmie w instrukcji nr 5

    public class StringHexPositionSort
    {
        //Zadeklaruj tablicę kolejek dla każdej cyfry szestnastkowej
        //Każda kolejka jest typu string
        private Queue<string>[] _queueArray = new Queue<string>[16];

        public Queue<string>[] getQueue
        {
            get => _queueArray;
        }

        private void Init()
        {
            //zaimplementuj zainicjowanie tablicy kolejek
            for (int i = 0; i < 16; i++)
            {
                if (_queueArray[i] == null)
                {
                    _queueArray[i] = new Queue<string>();
                }
                else
                {
                    _queueArray[i].Clear();
                }
            }
        }

        private void Dequeue(string[] arr)
        {
            int index = 0;
            for (int i = 0; i < 16; i++)
            {
                while (_queueArray[i].Count > 0)
                {
                    arr[index++] = _queueArray[i].Dequeue();
                }
            }
        }

        //Zaimplementuj metodę, aby zwracała liczbę równą cyfrze szesnastkowej na podanej pozycji (position) w łańcuchu str
        //Pozycja jest numerowana od prawej do lewej
        // np. dla łańcucha "AB12"
        // cyfra na pozycji 0 to 2,
        // cyfra na pozycji 2 to 11,
        // cyfra na pozycji 8 to 0
        private int ExtractDigit(string str, uint position)
        {
            str = string.Format("{0}", str);
            if (str.Length <= position - 1)
            {
                return 0;
            }
            return Convert.ToInt32(str[(int)(str.Length - position)] + "", 16);
        }
        //zaimplementuj umieszczanie liczb łacuchów z liczbami hex w kolejce odpowiadającej cyfrze na podanej pozycji
        private void Enqueue(string[] arr, uint position)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int digit = ExtractDigit(arr[i], position);
                _queueArray[digit].Enqueue(arr[i]);
            }
        }
        //Tej metody nie zmieniaj!!!
        public void Sort(string[] arr, int d)
        {
            Init();
            for (uint position = 0; position < d; position++)
            {
                Enqueue(arr, position);
                Dequeue(arr);
            }

        }
    }
}