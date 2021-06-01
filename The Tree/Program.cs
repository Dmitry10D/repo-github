using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree Tree = new BinarySearchTree();
            while(true)
            {
                string command = Console.ReadLine();

                if (command == "add") Tree.AddItem(Int32.Parse(Console.ReadLine()));
                if (command == "search") Tree.GetNodeByValue(Int32.Parse(Console.ReadLine()));
                if (command == "root") Tree.GetRoot();
                if (command == "print") BinarySearchTree.PrintArray(Tree);
                
            }
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null) return false;

            return node.Value == Value;
        }
    }

    public class BinarySearchTree : ITree
    {
        public TreeNode Root;

        public BinarySearchTree ()
        {
            Root = null;
        }
        public TreeNode GetRoot()
        {
            return Root;
        }

        //public TreeNode GetNodeByValue(int value) //без рекурсии, потому что такая дурацкая сигнатура метода была дана в задании
        //{
        //    var tmp = Root;
        //    if (Root != null)
        //    {
        //        while (tmp.Value != value)
        //        {
        //            if (tmp == null) continue;
        //            if (tmp.Value < value)
        //            {
        //                tmp = tmp.LeftChild;
        //            }
        //            else
        //            {
        //                tmp = tmp.RightChild;
        //            }

        //        }
        //        return tmp;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //} 

        //public void AddItem(int value) //без рекурсии
        //{
        //    var tmp = Root;
        //    if (Root != null)
        //    {
        //        while (tmp != null)
        //        {
        //            if (tmp.Value == value)
        //            {
        //                return; //allready exist
        //            }
        //            if (tmp.Value < value)
        //            {
        //                if (tmp.RightChild!=null)
        //                tmp = tmp.RightChild;
        //                else 
        //                {
        //                    TreeNode newNode = new TreeNode { Value = value };
        //                    tmp.RightChild = newNode;
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                if (tmp.LeftChild != null)
        //                    tmp = tmp.LeftChild;
        //                else
        //                {
        //                    TreeNode newNode = new TreeNode { Value = value };
        //                    tmp.LeftChild = newNode;
        //                    return;
        //                }
        //            }
        //        }


        //    }
        //    else
        //    {
        //        Root = new TreeNode { Value = value };
        //    }

        //} 

        //public void RemoveItem (int value) //без рекурсии не получилось, очень сложно
        //{
        //    var tmp = Root;
        //    if (Root != null)
        //    {
        //        if (Root.Value == value)
        //        {
        //            if (Root.LeftChild == null && Root.RightChild == null)
        //            {
        //                Root = null;
        //                return;
        //            }
        //            if (Root.LeftChild != null && Root.RightChild == null)
        //            {
        //                Root = Root.LeftChild;
        //                return;
        //            }
        //            if (Root.LeftChild == null && Root.RightChild != null)
        //            {
        //                Root = Root.RightChild;
        //                return;
        //            }
        //            else
        //            {

        //            }
        //        }
        //        while (tmp != null)
        //        {
        //            if (tmp.Value == value)
        //            {
        //                return; //allready exist
        //            }
        //            if (tmp.Value < value)
        //            {
        //                tmp = tmp.RightChild;

        //            }
        //            else
        //            {
        //                tmp = tmp.LeftChild;

        //            }
        //        }


        //    }
        //} 

        public void AddItem (int value)
        {
            AddNode(this.Root, value);
        }
        private TreeNode AddNode (TreeNode Root, int value)
        {
            var tmp = Root;
            if (tmp == null)
            {
                tmp = new TreeNode() { Value = value };

            }
            else
            {
                if(tmp.Value == value)
                {
                    return tmp;
                }
                else if (value < tmp.Value)
                {
                    tmp.LeftChild = AddNode(tmp.LeftChild, value);
                }
                else
                {
                    tmp.RightChild = AddNode(tmp.RightChild, value);
                }
            }
            return tmp;
        }

        public void RemoveItem (int value)
        {
            RemoveNode(Root, value);
        }

        private TreeNode RemoveNode (TreeNode node, int value)
        {
            if (node == null)
            {
                return node;
            }
            else
            {
                if (node.Value == value)
                {
                    if (node.LeftChild != null && node.RightChild != null)
                    {
                        node.Value = node.RightChild.LeftChild.Value;
                        RemoveNode(node.RightChild.LeftChild, value);
                        return node;
                    }
                    else if (node.LeftChild != null && node.RightChild == null)
                    {
                        node = node.LeftChild;
                        return node;
                    }
                    else if (node.LeftChild == null && node.RightChild != null)
                    {
                        node = node.RightChild;
                        return node;
                    }
                    else
                    {
                        node = null;
                        return node;
                    }
                }
                else if (node.Value < value)
                {
                    RemoveNode(node.RightChild, value);
                    return node;
                }
                else
                {
                    RemoveNode(node.LeftChild, value);
                    return node;
                }
            }
        }

        public TreeNode GetNodeByValue (int value)
        {
            return GetNode(Root, value);
        }

        private TreeNode GetNode (TreeNode node, int value)
        {
            if(node != null)
            {
                if (node.Value == value)
                {
                    return node;
                }
                else if (node.Value > value)
                {
                    return GetNode(node.LeftChild, value);
                }
                else
                {
                    return GetNode(node.RightChild, value);
                }
            }
            else return null;
        }

        public void PrintTree ()
        {

        }

        public static void PrintArray (ITree tree)
        {
            NodeInfo[] arr = TreeHelper.GetTreeInLine(tree);
            var i = 0;
            while (i<arr.Length)
            {
                for (var j = i; j <= 2 * i; j++)
                {
                    Console.Write('(' + arr[j].Node.Value +')'+' ');
                }
                Console.WriteLine();
                i = i * 2;
            }
        }

    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value);
        void RemoveItem(int value);
        TreeNode GetNodeByValue(int value);
        void PrintTree();
    }
    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }
    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if(element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth
                    };
                    bufer.Enqueue(right);
                }
            }
            return returnArray.ToArray();
        }   
    }
}

//TreeNode tmp = null;
//if (head == null)
//{
//    head = GetFreeNode(value, null);
//    //head.Value = value;
//    return head;
//}
//tmp = head;
//while (tmp != null)
//{
//    if (tmp.Value < value)
//    {
//        if (tmp.LeftChild != null)
//        {
//            tmp = tmp.LeftChild;
//            continue;
//        }
//        else
//        {
//            tmp.LeftChild = GetFreeNode(value, tmp);
//            return head;
//        }
//    }
//    else if (tmp.Value > value)
//    {
//        if (tmp.RightChild != null)
//        {
//            tmp = tmp.RightChild;
//            continue;
//        }
//        else
//        {
//            tmp.RightChild = GetFreeNode(value, tmp);
//            return head;
//        }
//    }
//    else
//    {
//        throw new Exception("Wrong tree state");
//    }
//}
//return head;
