using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Algorithm
{
    public static class CalculatePointDistance
    {
        public static float DistanceBetweenPoints(PointClass<float> a, PointClass<float> b)
        {
            var x = b.X - a.X;
            var y = b.Y - a.Y;
            return (float)Math.Sqrt(x*x + y*y);
        }

        public static float DistanceBetweenPoints(PointStruct a, PointStruct b)
        {
            var x = b.X - a.X;
            var y = b.Y - a.Y;
            return (float)Math.Sqrt(x * x + y * y);
        }

        public static double DistanceBetweenPoints(PointClass<double> a, PointClass<double> b)
        {
            var x = b.X - a.X;
            var y = b.Y - a.Y;
            return Math.Sqrt(x * x + y * y);
        }

        public static float DistanceBetweenPointsWithoutSqrt(PointStruct a, PointStruct b)
        {
            var x = b.X - a.X;
            var y = b.Y - a.Y;
            return (float)(x * x + y * y);
        }
    }
}
