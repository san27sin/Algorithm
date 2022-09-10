using System;

namespace Algorithm
{
    class Program
    {       

        static void Main(string[] args)
        {
            Task_1(); 
        }

        private static void Task_1()
        {            
            Console.WriteLine("Введите размер прямоугольника в ширину и длину:");
            int m = 0;
            int n = 0;

            do
            {
              Console.Write("m = ");                
            } while (!int.TryParse(Console.ReadLine(), out m)||m<=0);

            do
            {
                Console.Write("n = ");
            } while (!int.TryParse(Console.ReadLine(), out n)||n<=0);

            int[,] array = CreateAndFillArray(m, n);
            PrintArray(array);

        }

        private static int[,] CreateAndFillArray(int m,int n)
        { 
            int[,] array = new int[m, n];

            for(int row = 0; row < m; row++)
                for(int col = 0; col < n; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        array[row, col] = 0;
                        continue;
                    }                     

                    if(row == 0 || col == 0)
                    {
                        array[row, col] = 1;
                        continue;
                    }

                    array[row, col] = array[row - 1, col] + array[row, col - 1];

                }

            return array;
        }

        private static void PrintArray(int[,] array)
        {
            Console.WriteLine();
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write(String.Format("{0,5}",array[row,col]));
                }
                Console.WriteLine();
            }            
        }
    }
}
