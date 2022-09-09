using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Program
    {
        //Отличие от дерева надо запоминать посещенные вершины, проверять по хэш
        public static void Main(string[] args)
        {
            var graph = new Graph();
            var vertex_1 = new Vertex(1);
            var vertex_2 = new Vertex(2);
            var vertex_3 = new Vertex(3);
            var vertex_4 = new Vertex(4);
            var vertex_5 = new Vertex(5);
            var vertex_6 = new Vertex(6);
            var vertex_7 = new Vertex(7);


            graph.AddVertex(vertex_1);
            graph.AddVertex(vertex_2);
            graph.AddVertex(vertex_3);
            graph.AddVertex(vertex_4);
            graph.AddVertex(vertex_5);
            graph.AddVertex(vertex_6);
            graph.AddVertex(vertex_7);

            graph.AddEdge(vertex_1, vertex_2,2);
            graph.AddEdge(vertex_1, vertex_3,4);
            graph.AddEdge(vertex_3, vertex_4,1);
            graph.AddEdge(vertex_2, vertex_5,9);
            graph.AddEdge(vertex_2, vertex_6,3);
            graph.AddEdge(vertex_6, vertex_5,8);
            graph.AddEdge(vertex_2, vertex_1, 4);
            //graph.AddEdge(vertex_5, vertex_6);

            //Поиск в ширину
            var path_1 = graph.BFS(vertex_1, vertex_5);//yes
            var path_2 = graph.BFS(vertex_1, vertex_4);//yes
            var path_3 = graph.BFS(vertex_2, vertex_4);//no
            var path_4 = graph.BFS(vertex_4, vertex_6);//no

            //Поиск в глубину
            var path_5 = graph.DFS(vertex_2, vertex_5);
            var path_6 = graph.DFS(vertex_2, vertex_4);
        }
         
    }
}
