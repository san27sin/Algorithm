using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algorithm
{
    [MemoryDiagnoser]
    [RankColumn]
    [HtmlExporter]
    public class BenchmarkTest
    {
        private PointClass<float>[] points_A_class;
        private PointClass<float>[] points_B_class;

        private PointStruct[] points_A_struct;
        private PointStruct[] points_B_struct;

        private PointClass<double>[] d_points_A_class;
        private PointClass<double>[] d_points_B_class;

        public BenchmarkTest()
        {
            points_A_class = new PointClass<float>[100];
            points_B_class = new PointClass<float>[100];
                   
            points_A_struct = new PointStruct[100];
            points_B_struct = new PointStruct[100];

            d_points_A_class = new PointClass<double>[100];
            d_points_B_class = new PointClass<double>[100];

            InitializeArray(points_A_class);
            InitializeArray(points_B_class);

            InitializeArray(points_A_struct);
            InitializeArray(points_B_struct);

            InitializeArray(d_points_A_class);
            InitializeArray(d_points_B_class);
        }

        public void InitializeArray(PointClass<float>[] points)
        {
            Random rand = new Random();
            for(int i = 0; i < points.Length; i++)
            {
                points[i] = new PointClass<float>();
                points[i].X = rand.Next(-50, 50);
                points[i].Y = rand.Next(-50, 50);
            }
        }

        public void InitializeArray(PointStruct[] points)
        {
            Random rand = new Random();
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointStruct();
                points[i].X = rand.Next(-50, 50);
                points[i].Y = rand.Next(-50, 50);
            }
        }

        public void InitializeArray(PointClass<double>[] points)
        {
            double minRange = -50.0;
            double maxRange = 50.0;
            Random rand = new Random();
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointClass<double>();
                points[i].X = Math.Floor(rand.NextDouble() * (maxRange - minRange) + minRange);
                points[i].Y = Math.Floor(rand.NextDouble() * (maxRange - minRange) + minRange);
            }
        }



        [Benchmark(Description = "Дистанция между точками, класс, float")]
        public void Test_1()
        {
            for(int i = 0; i < points_A_class.Length; i++)
            {
                float dis = CalculatePointDistance.DistanceBetweenPoints(points_A_class[i], points_B_class[i]);
            }            
        }

        [Benchmark(Description = "Дистанция между точками, структура, float")]
        public void Test_2()
        {
            for(int i = 0; i < points_A_struct.Length; i++)
            {
                float dis = CalculatePointDistance.DistanceBetweenPoints(points_A_struct[i], points_B_struct[i]);
            }            
        }

        [Benchmark(Description = "Дистанция между точками, класс, double")]
        public void Test_3()
        {
            for(int i = 0; i < d_points_A_class.Length;i++)
            {
                double dis = CalculatePointDistance.DistanceBetweenPoints(d_points_A_class[i], d_points_B_class[i]);
            }            
        }

        [Benchmark(Description = "Дистанция между точками, структура, float, без вычисления квадрата")]
        public void Test_4()
        {
            for(int i = 0; i < points_A_struct.Length;i++)
            {
                double dis = CalculatePointDistance.DistanceBetweenPointsWithoutSqrt(points_A_struct[i], points_B_struct[i]);
            }            
        }
    }
}
