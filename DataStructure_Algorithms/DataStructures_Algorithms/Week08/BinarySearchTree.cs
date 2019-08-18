using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Week04;

namespace DataStructures_Algorithms
{
    public partial class BinarySearchTree<T>
    {
        public void BFS(TextWriter tw)
        {
            System.Collections.Generic.Queue<BSTNode<T>> traversalQueue = new System.Collections.Generic.Queue<BSTNode<T>>();

            traversalQueue.Enqueue(Root);

            while (traversalQueue.Count > 0)
            {
                var tmp = traversalQueue.Dequeue();
                tw.WriteLine(tmp.Value);
                traversalQueue.Enqueue(tmp.LeftChild);
                traversalQueue.Enqueue(tmp.RightChild);
            }
        }
        public void DFS(TextWriter tw)
        {
            Week04.Stack<BSTNode<T>> traversalQueue = new Week04.Stack<BSTNode<T>>();

            traversalQueue.Push(Root);

            while (traversalQueue.Count > 0)
            {
                var tmp = traversalQueue.Pop();
                tw.WriteLine(tmp.Value);
                traversalQueue.Push(tmp.LeftChild);
                traversalQueue.Push(tmp.RightChild);
            }
        }
    }
}
