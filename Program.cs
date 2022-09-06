using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new TreeNode() { };
            tree.AddItem(10);
            tree.AddItem(8);
            tree.AddItem(12);
            tree.AddItem(20);
            tree.AddItem(11);
            tree.AddItem(6);
            tree.AddItem(9);
            tree.AddItem(5);
            tree.AddItem(7);
            tree.AddItem(13);
            tree.AddItem(21);
            tree.AddItem(14);
            tree.AddItem(15);            
            var answer_7 = tree.BFS(7);
            var answer_8 = tree.BFS(16);
            var answer_9 = tree.DFS(45);
            var answer_10 = tree.DFS(20);
        }
         
    }
}
