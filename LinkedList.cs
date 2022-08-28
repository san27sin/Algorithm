using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class LinkedList : ILinkedList
    {
        private int _count;
        public Node _nodeStart;
        private Node _nodeEnd;

        public void AddNode(int value)
        {
            var newNode = new Node() { Value = value };

            if (_nodeStart == null)
            {
                _nodeStart = newNode;
            }
            else
            {
                _nodeEnd.NextNode = newNode;
                newNode.PrevNode = _nodeEnd;
            }
            _nodeEnd = newNode;
            _count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node() { Value = value };
            Node temp = _nodeStart;
            while (!temp.Equals(node))
            {
                temp = temp.NextNode;
                if (temp == null)
                    return;
            }
            newNode.NextNode = temp.NextNode;
            newNode.PrevNode = temp;
            temp.NextNode.PrevNode = newNode;
            temp.NextNode = newNode;
        }

        public Node FindNode(int searchValue)
        {
            Node temp = _nodeStart;
            while (!(temp.Value == searchValue))
            {
                temp = temp.NextNode;
                if (temp == null)
                    return null;
            }
            return temp;
        }

        public int GetCount()
        {
            return _count;
        }

        public void RemoveNode(int index)
        {
            if (index < 0 || index > _count)
                return;

            Node temp = _nodeStart;
            for (int i = 0; i < index; i++)
            {
                temp = temp.NextNode;
            }           

            if (temp.NextNode != null)
                temp.NextNode.PrevNode = temp.PrevNode;

            if(temp.PrevNode!=null)//проверка для первого элемента
                temp.PrevNode.NextNode = temp.NextNode;//вызвало ошибку

            if(_nodeStart == temp)
                _nodeStart = temp.NextNode;

            if(_nodeEnd == temp)
                _nodeEnd = temp.PrevNode;

            temp = null; 
            _count--;
        }

        public void RemoveNode(Node node)
        {
            Node temp = _nodeStart;
            while (!temp.Equals(node))
            {
                temp = temp.NextNode;
                if (temp == null)
                    return;
            }

            if (temp.NextNode != null)
                temp.NextNode.PrevNode = temp.PrevNode;

            if (temp.PrevNode != null)//проверка для первого элемента
                temp.PrevNode.NextNode = temp.NextNode;

            if (_nodeStart == temp)
                _nodeStart = temp.NextNode;

            if (_nodeEnd == temp)
                _nodeEnd = temp.PrevNode;

            temp = null;
            _count--;
        }
    }
}
