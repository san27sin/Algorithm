using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Sorts
    {
        /// <summary>
        /// Блочная сортировка
        /// </summary>
        /// <param name="array">не отсартированный массив</param>
        /// <returns>отсортированный массив</returns>
        public static int[] BucketSort(int[] array)
        {
            if (array.Length == 1)
                return array;

            (double max, double min) = MinAndMax(array);

            double k = Math.Ceiling((max - min) / array.Length);

            int count = 0;

            List<List<int>> list = new List<List<int>>();
            List<int> list_sorted = new List<int>();

            while (array.Length != count)
            {
                list.Add(new List<int>());

                max = min + k;

                for (int a = 0; a < array.Length; a++)
                {
                    if (array[a] >= min && array[a] < max)
                        list[count].Add(array[a]);
                }

                min = max;

                if (list[count] != null)
                {
                    for (int a = 0; a < list[count].Count - 1; a++)
                    {
                        for (int b = 1; b < list[count].Count; b++)
                        {
                            if (list[count][a] > list[count][b])
                            {
                                int temp = list[count][a];
                                list[count][a] = list[count][b];
                                list[count][b] = temp;
                            }
                        }
                    }
                    list_sorted.AddRange(list[count]);
                }
                count++;
            }
            return list_sorted.ToArray();
        }

        private static (int, int) MinAndMax(int[] array)
        {
            int max = 0;
            int min = 0;

            for (int a = 0; a < array.Length; a++)
            {
                if (a == 0)
                {
                    min = array[a];
                    max = array[a];
                }

                if (array[a] < min)
                    min = array[a];

                if (array[a] > max)
                    max = array[a];
            }

            return (max, min);
        }

        /// <summary>
        /// Внешняя сортировка слиянием
        /// </summary>
        /// <param name="fileInput">Входной файл с большим кол-во данных</param>
        static public void ExtentionMergeSort(string fileInput)
        {
            if (!File.Exists(fileInput))
                return;

            ulong iterations = 1, segments = 0;
            while (true)
            {
                SplitToFiles(fileInput, ref segments, ref iterations);
                if (segments == 1)
                {
                    break;
                }
                MergePairs(fileInput, ref iterations);
            }
        }

        static private void SplitToFiles(string fileInput, ref ulong segments, ref ulong iterations) // разделение на 2 вспом. файла
        {
            segments = 1;
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileInput)))
            using (BinaryWriter writerA = new BinaryWriter(File.Create("a.bin", 65536)))
            using (BinaryWriter writerB = new BinaryWriter(File.Create("b.bin", 65536)))
            {
                ulong counter = 0;
                bool flag = true; // запись либо в 1-ый, либо во 2-ой файл

                long length = br.BaseStream.Length;
                long position = 0;
                while (position != length)
                {
                    // если достигли количества элементов в последовательности -
                    // меняем флаг для след. файла и обнуляем счетчик количества
                    if (counter == iterations)
                    {
                        flag = !flag;
                        counter = 0;
                        segments++;
                    }

                    int element = br.ReadInt32();
                    position += 4;
                    if (flag)
                    {
                        writerA.Write(element);
                    }
                    else
                    {
                        writerB.Write(element);
                    }
                    counter++;
                }
            }
        }

        static private void MergePairs(string fileInput, ref ulong iterations) // слияние отсорт. последовательностей обратно в файл
        {
            using (BinaryReader readerA = new BinaryReader(File.OpenRead("a.bin")))
            using (BinaryReader readerB = new BinaryReader(File.OpenRead("b.bin")))
            using (BinaryWriter bw = new BinaryWriter(File.Create(fileInput, 65536)))
            {
                ulong counterA = iterations, counterB = iterations;
                int elementA = 0, elementB = 0;
                bool pickedA = false, pickedB = false, endA = false, endB = false;
                long lengthA = readerA.BaseStream.Length;
                long lengthB = readerB.BaseStream.Length;
                long positionA = 0;
                long positionB = 0;
                while (!endA || !endB)
                {
                    if (counterA == 0 && counterB == 0)
                    {
                        counterA = iterations;
                        counterB = iterations;
                    }

                    if (positionA != lengthA)
                    {
                        if (counterA > 0 && !pickedA)
                        {
                            elementA = readerA.ReadInt32();
                            positionA += 4;
                            pickedA = true;
                        }
                    }
                    else
                    {
                        endA = true;
                    }

                    if (positionB != lengthB)
                    {
                        if (counterB > 0 && !pickedB)
                        {
                            elementB = readerB.ReadInt32();
                            positionB += 4;
                            pickedB = true;
                        }
                    }
                    else
                    {
                        endB = true;
                    }

                    if (pickedA)
                    {
                        if (pickedB)
                        {
                            if (elementA < elementB)
                            {
                                bw.Write(elementA);
                                counterA--;
                                pickedA = false;
                            }
                            else
                            {
                                bw.Write(elementB);
                                counterB--;
                                pickedB = false;
                            }
                        }
                        else
                        {
                            bw.Write(elementA);
                            counterA--;
                            pickedA = false;
                        }
                    }
                    else if (pickedB)
                    {
                        bw.Write(elementB);
                        counterB--;
                        pickedB = false;
                    }
                }

                iterations *= 2; // увеличиваем размер серии в 2 раза
            }
        }

    }
}
