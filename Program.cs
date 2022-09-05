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
            BenchmarkRunner.Run<BenchmarkTestHashSetAndArray>();
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
            var answer_1 = tree.GetRoot();
            var answer_2 = tree.GetNodeByValue(10);
            var answer_3 = tree.GetNodeByValue(21);
            var answer_4 = tree.GetNodeByValue(30);
            var answer_5 = TreeHelper.GetTreeInLine(tree);
            var answer_6 = new NodeInfo() { Node = answer_3 };
            tree.PrintTree();
        }
         
    }
}
