using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    [MemoryDiagnoser]
    [RankColumn]
    public class BenchmarkTestHashSetAndArray
    {
        private protected static HashSet<string> _hash_data = null;
        private protected static string[] _array_data = null;
        private protected static string _test = "test";

        public BenchmarkTestHashSetAndArray()
        {
            Task1();
        }

        public void Task1()
        {
            _hash_data = new HashSet<string>();
            _array_data = new string[10_000];

            GenerateString.FillRandomString(_array_data);
            GenerateString.FillRandomString(_hash_data, 10_000);
        }

        [Benchmark(Description = "Нахождение элемента в массива")]
        public void Test_Array()
        {
            var answer = _array_data.Contains(_test);
        }

        [Benchmark(Description = "Нахождение элемента в HashSet")]
        public void Test_Hash()
        {
            var answer = _hash_data.Contains(_test);
        }
    }
}
