using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public sealed class TestBinarySearch
    {
        private int _passedNumber;
        private int _expectedNumber;
        private int[] _testArray;

        /// <summary>
        /// Ввод данных для тестирования
        /// </summary>
        /// <param name="passedNumber">искомое число</param>
        /// <param name="expectedNumber">ожидаемый индекс числа</param>
        /// <param name="testArray">массив для поиска</param>
        public TestBinarySearch(int passedNumber, int expectedNumber, int[] testArray)
        {
            _passedNumber = passedNumber;
            _expectedNumber = expectedNumber;
            _testArray = testArray;
        }


        public static bool TestBS(TestBinarySearch test)
        {
            if (BinarySearch.BinSearch(test._testArray, test._passedNumber) == test._expectedNumber)
                return true;
            else
                return false;
        }
    }
}
