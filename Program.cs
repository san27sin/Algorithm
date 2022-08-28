using System;
using System.Collections.Generic;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            
            LinkedList linkedList = new LinkedList();            

            linkedList.AddNode(5);
            linkedList.AddNode(10);
            linkedList.AddNode(15);
            linkedList.AddNode(20);
            linkedList.AddNode(25);
            
            int count_1 = linkedList.GetCount();
            Node one = linkedList.FindNode(15);
            linkedList.AddNodeAfter(one, 17);
            
            linkedList.RemoveNode(1);

            linkedList.RemoveNode(10);
            linkedList.RemoveNode(-1);

            var node = new Node() { Value = 19 };
            linkedList.RemoveNode(node);

            linkedList.RemoveNode(one);
            int count_2 = linkedList.GetCount();
            

            linkedList.RemoveNode(0);
            linkedList.RemoveNode(linkedList.GetCount() - 1);


            //Логаримфическая асимптоническая сложность у бинарного поиска
            var test_1 = new TestBinarySearch(12, 4, new int[6] { 4, 9, 7, 10, 14, 12 });
            bool answer_1 = TestBinarySearch.TestBS(test_1);

            var test_2 = new TestBinarySearch(10, 4, new int[6] { 4, 9, 7, 10, 14, 12 });
            bool answer_2 = TestBinarySearch.TestBS(test_2);
        }
    }
}
