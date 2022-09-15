using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class TestSorts
    {
        public int[] Given { get; set; }
        public int[] Expected { get; set; }

        /// <summary>
        /// Конструтор
        /// </summary>
        /// <param name="given">массив для сортировки</param>
        /// <param name="expected">ожидаемый массив после сортировки</param>
        public TestSorts(int[] given, int[] expected)
        {
            Given = given;
            Expected = expected;
        }

        public static bool TestBucketSort(TestSorts test)
        {
            return test.Expected.SequenceEqual(Sorts.BucketSort(test.Given));
        }
    }
}
