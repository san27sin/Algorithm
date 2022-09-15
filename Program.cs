using System;
using System.Collections.Generic;
using System.IO;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_1();
            Test_2();
        }


        /// <summary>
        /// Тест на работоспособность 1 пункта домашнего задания
        /// </summary>
        static void Test_1()
        {
            int[] array_1 = new int[5] { 5, -2, 6, 1, -10 };
            int[] array_2 = new int[5] { -10, -2, 1, 6, 5 };

            var test = new TestSorts(array_1, array_2);
            bool answer_1 = TestSorts.TestBucketSort(test);

            test.Given = new int[1] { 32 };
            test.Expected = new int[1] { 32 };
            bool answer_2 = TestSorts.TestBucketSort(test);

            test.Given = new int[1] { 32 };
            test.Expected = new int[1] { 22 };
            bool answer_3 = TestSorts.TestBucketSort(test);

            test.Given = new int[5] { 5, -2, 6, 1, -10 };
            test.Expected = new int[5] { -10, -2, 1, 5, 6 };
            bool answer_4 = TestSorts.TestBucketSort(test);
        }

        /// <summary>
        /// Тест на работоспособность 2 пункта домашнего задания
        /// </summary>
        public static void Test_2()
        {
            string fileName = "data.bin";
            if(!File.Exists(fileName))
                File.Create(fileName);

            LargeFileGeneration(fileName);
            Sorts.ExtentionMergeSort(fileName);
        }


        public static void LargeFileGeneration(string file)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Create(file)))
            {
                Random rnd = new Random();
                for (int i = 0; i < 25600; i++)
                {
                    bw.Write(rnd.Next(-500, 500));
                }
            }
        }
    }
}
