using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algorithm
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkTest>();                     
        }         
    }
}
