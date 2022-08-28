using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class BinarySearch
    {
        public static int BinSearch(int[] array, int searchNumber)
        {
            QuickSort(array);//отсортируем массив
            if (searchNumber < array[0] || searchNumber > array[array.Length - 1])
                return -1;

            int max = array.Length - 1;
            int min = 0;            

            do
            {
                int mid = (min+max)/ 2;
                if (array[mid] == searchNumber)
                    return mid;
                if (array[mid] > searchNumber)
                    max = mid - 1;
                if (array[mid] < searchNumber)
                    min = mid + 1;
            } while (true);
        }

        public static void QuickSort(int[] array)
        {
            for(int i = 0; i < array.Length;i++)
            {
                for(int j = 0; j < array.Length-1;j++)
                {
                    if(array[j]>array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }                        
        }
    }
}
