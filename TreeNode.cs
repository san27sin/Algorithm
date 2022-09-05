using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class TreeNode : ITree
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }

        private int _count = 10;

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;
            if (node == null)
                return false;
            return node.Value == Value;
        }

        public void AddItem(int value)
        {
            if(Value == default)
            {
                this.Value = value;
                return;
            }

            if(value <= Value)
            {
                if(LeftChild == null)
                {
                    LeftChild = new TreeNode() { Value = value };
                    LeftChild.Parent = this;
                    return;
                }

                TreeNode nodeTree = LeftChild;
                AddNewNode(nodeTree, value);       
                                
            }

            if (value >= Value)
            {
                if (RightChild == null)
                {
                    RightChild = new TreeNode() { Value = value };
                    RightChild.Parent = this;
                    return;
                }

                TreeNode nodeTree = RightChild;
                AddNewNode(nodeTree, value);
            }
        }

        private void AddNewNode(TreeNode nodeTree, int value)
        {
            while (true)
            {
                if (value <= nodeTree.Value)
                {
                    if (nodeTree.LeftChild == null)
                    {
                        nodeTree.LeftChild = new TreeNode() { Value = value };
                        nodeTree.LeftChild.Parent = nodeTree;
                        return;
                    }
                    nodeTree = nodeTree.LeftChild;
                }
                else
                {
                    if (nodeTree.RightChild == null)
                    {
                        nodeTree.RightChild = new TreeNode() { Value = value };
                        nodeTree.RightChild.Parent = nodeTree;
                        return;
                    }
                    nodeTree = nodeTree.RightChild;
                }
            }
        }

        public TreeNode GetRoot()
        {
            return this;
        }

        public void PrintTree()
        {
            print2DUtil(this, 0);
        }

        private void print2DUtil(TreeNode root, int space)
        {
            if (root == null)
                return;

            space += _count;

            print2DUtil(root.RightChild, space);

            Console.Write("\n");
            for (int i = _count; i < space; i++)
                Console.Write(" ");
            Console.Write(root.Value + "\n");

            print2DUtil(root.LeftChild, space);
        }


        public void RemoveItem(int value)
        {
            if (value == Value)
            {
                ReplaceValue(this);
                return;
            }

            if (value < Value)
            {
                if (LeftChild == null)
                    return;

                TreeNode nodeTree = LeftChild;
                nodeTree = FindNode(nodeTree, value);
                ReplaceValue(nodeTree);
                return;
            }

            if (value > Value)
            {
                if (RightChild == null)
                    return;

                TreeNode nodeTree = RightChild;
                nodeTree = FindNode(nodeTree, value);
                ReplaceValue(nodeTree);
                return;
            }
        }

        private TreeNode FindNode(TreeNode nodeTree, int value)
        {
            while (value != nodeTree.Value)
            {
                if (value > nodeTree.Value)
                {
                    nodeTree = nodeTree.RightChild;
                    if (nodeTree == null)
                        return null;
                }
                else
                {
                    nodeTree = nodeTree.LeftChild;
                    if (nodeTree == null)
                        return null;
                }
            }
            return nodeTree;
        }

        private void ReplaceValue(TreeNode nodeTree)
        {
            if (nodeTree.LeftChild == null && nodeTree.RightChild == null)
            {
                if (nodeTree.Parent.LeftChild.Value == nodeTree.Value)
                    nodeTree.Parent.LeftChild = null;
                else
                    nodeTree.Parent.RightChild = null;
                return;
            }

            if (nodeTree.LeftChild == null)
            {
                nodeTree.RightChild.Parent = nodeTree.Parent;
                nodeTree = null;
                return;
            }

            if (nodeTree.RightChild == null)
            {
                nodeTree.LeftChild.Parent = nodeTree.Parent;
                nodeTree = null;
                return;
            }

            TreeNode nodeTreeReplace = nodeTree.RightChild;
            while (true)
            {
                nodeTreeReplace = nodeTreeReplace.LeftChild;
                if (nodeTreeReplace.LeftChild == null)
                    break;
            }

            nodeTree.Value = nodeTreeReplace.Value;
            if (nodeTreeReplace.RightChild != null)
                nodeTreeReplace.Parent.LeftChild = nodeTreeReplace.RightChild;
            else
                nodeTreeReplace.Parent.LeftChild = null;
        }

        public TreeNode GetNodeByValue(int value)
        {
            if (value == Value)
                return this;

            if (value < Value)
                return FindNode(this.LeftChild, value);
            else
                return FindNode(this.RightChild, value);
        }
    }

}

