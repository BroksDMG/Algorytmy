using System;
namespace task_2
{
    public class Task2
    {

        public static void Main(string[] args)
        {
            //task2
            int[] arr1 = { 0, 2, 4, 6 };
            int[] arr2 = { -2, -1, 10, 10_000, -1 };
            //int[] arr3 = { 2, 1, 10, 10_000, 1 };


            Console.WriteLine(MinProduct(arr1));
            Console.WriteLine(MinProduct(arr2));
            //Console.WriteLine(MinProduct(arr3));
            //task1

            int[,] gold = new int[,] { { 1, 3, 1, 5 },
                                       { 2, 2, 4, 1 },
                                       { 5, 0, 2, 3 },
                                       { 0, 6, 1, 2 } };
            Console.WriteLine(CollectGold(gold));
        }

        /// <summary>
        /// W tablicy gold znajdują się dodatnie liczby reprezetujące złoto. 
        /// Górnik zbiera złoto z komórek, zaczyna od dowolnej komórki górnego wiersza (n) i 
        /// i porusza się w dół do dolnego wiersza (0). Może przejść tylko do komórki po prawej lub
        /// do komórki na przekątnej: w prawo w górę lub w prawo w dół, ale ostatecznie musi znaleźć się w dolnym wierszu (0).
        /// Zaimplementuj algorytm, który wyznaczy największa liczbę złota zebraną przez górnika.
        /// </summary>
        /// <param name="gold">Dwuwymiarowa tablica liczb dodatnich</param>
        /// <returns>Liczba zebranego złota</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <summary>
        // Przykłady
        // Wejście: gold[][] = {{1, 3, 3},
        //     {2, 1, 4},
        //     {0, 6, 4}};
        // Wyjście: 12
        // {(1,0)->(2,1)->(1,2)}
        //
        // Wejście: gold[][] = { {1, 3, 1, 5},
        //     {2, 2, 4, 1},
        //     {5, 0, 2, 3},
        //     {0, 6, 1, 2}};
        // Wyjście: 16
        //     (2,0) -> (1,1) -> (1,2) -> (0,3) LUB
        //     (2,0) -> (3,1) -> (2,2) -> (2,3)
        //
        // Wejście : gold[][] = {{10, 33, 13, 15},
        //     {22, 21, 04, 1},
        //     {5, 0, 2, 3},
        //     {0, 6, 14, 2}};
        // Wyjście: 83 
        // Uwaga!!!
        // Najłatwiej zrealizować algorytm w postaci rekurencyjnej.
        // Memoizacja zmniejszy złożoność czasową.
        static public int CollectGold(int[,] gold)
        {
            int width = gold.GetLength(0);
            int height = gold.GetLength(1);
            int[,] memo = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    memo[i, j] = -1;
                }
            }

            int max = 0;
            for (int i = 0; i < width; i++)
            {
                max = Math.Max(max, CollectGoldHelper(gold, i, height - 1, memo));
            }

            return max;
        }
        static public int CollectGoldHelper(int[,] gold, int row, int col, int[,] memo)
        {
            if (col == 0)
            {
                return gold[row, col];
            }

            if (memo[row, col] != -1)
            {
                return memo[row, col];
            }

            int max = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i >= 0 && i < gold.GetLength(0))
                {
                    max = Math.Max(max, CollectGoldHelper(gold, i, col - 1, memo));
                }
            }

            memo[row, col] = max + gold[row, col];
            return memo[row, col];
        }

        /// <summary>
        /// Zaimplementuj funkcję, która wyznaczy najmniejszy ilocz wybranych liczb z tablicy arr.
        /// Iloczyn może składać się z jednej liczby.
        /// Przykład 1
        /// Wejscie: int[] arr = [0, 2, 4, 6]
        /// Wyjście: 0
        /// 
        /// Przykład 2
        /// Wejscie: int[] arr = [-2, -1, 10, 10_000, -1]
        /// Wyjście: -200_000
        /// 
        /// Przykład 3
        /// Wejscie: int[] arr = [2, 1, 10, 10_000, 1]
        /// Wyjście: 1
        /// </summary>
        /// <param name="arr">tablica liczb całkowitych</param>
        /// <returns>najmniejszy iloczyn tablicy wejściowej arr</returns>
        static public int MinProduct(int[] a)
        {
            int n = a.Length;

            if (n == 1)
                return a[0];

            int negmax = int.MinValue;
            int posmin = int.MinValue;
            int count_neg = 0, count_zero = 0;
            int prod = 1;

            for (int i = 0; i < n; i++)
            {
                if (a[i] == 0)
                {
                    count_zero++;
                    continue;
                }

                if (a[i] < 0)
                {
                    count_neg++;
                    negmax = Math.Max(negmax, a[i]);
                }

                if (a[i] > 0 && a[i] < posmin)
                    posmin = a[i];
                

                prod *= a[i];
            }

            if (count_zero == n|| (count_neg == 0 && count_zero > 0))
                return 0;


            if (count_neg == 0)
                return posmin;


            if (count_neg % 2 == 0 && count_neg != 0)
               prod = prod / negmax;
           

            return prod;
        }
    }
}
