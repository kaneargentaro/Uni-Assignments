using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructures_Algorithms
{
	public class BSTNode<T>
	{
		public BSTNode<T> LeftChild { get; set; }
		public BSTNode<T> RightChild { get; set; }
		public T Value { get; set; }
	}
	public class BinarySearchTree<T>
	{
		public BSTNode<T> Root { get; set; }
		public BinarySearchTree()
		{
		}

		public void Add(T element)
		{
			Root = Add(Root, element);
		}

		BSTNode<T> Add(BSTNode<T> node, T element)
		{
			//TODO: Please make sure to read and understand the Add node method

			var comparer = Comparer<T>.Default;

			//if node to add to is null (root is null, or we are adding a leaf node),
			//then create a new node
			if (node == null)
				node = new BSTNode<T> { Value = element, LeftChild = null, RightChild = null };

			else
			{
				//else compare the node value with the element
				var result = comparer.Compare(element, node.Value);

				//if less than or equal, then try to add it on the left branch
				if (result <= 0)
					node.LeftChild = Add(node.LeftChild, element);
				else
				//else, add it to the right branch
					node.RightChild = Add(node.RightChild, element);
			}

			return node;
		}

		public void Traverse(TraversalMode mode, TextWriter tw)
		{
			switch (mode)
			{
				case TraversalMode.PRE: PreOrder_Traverse(Root, tw); break;
				case TraversalMode.POST: PostOrder_Traverse(Root, tw); break;
				case TraversalMode.IN: InOrder_Traverse(Root, tw); break;
			}

		}

		void InOrder_Traverse(BSTNode<T> node, TextWriter tw)
		{
			//TODO: Complete the In ORDER as follows (see the PreOrder_Traverse method)
			//Print nodes on the left

			//then print the node value

			//then print nodes on the right


			
		}

		void PostOrder_Traverse(BSTNode<T> node, TextWriter tw)
		{
			

			//TODO: Complete the POST ORDER as follows (see the PreOrder_Traverse method)
			//Print nodes on the left

			//then print nodes on the right

			//then print the node value


		}

		public BSTNode<T> Search(T element)
		{
			return Search(Root, element);
		}

		BSTNode<T> Search(BSTNode<T> node, T element)
		{
			if (node == null) return null;
					   
			var comparer = Comparer<T>.Default;
			var result = comparer.Compare(element, node.Value);

			if (result == 0) return node;

			else if (result < 0)
				return Search(node.LeftChild, element);
			else
				//else, add it to the right branch
				return Search(node.RightChild, element);
		}

		public T Min(BSTNode<T> node)
		{
			if (node.LeftChild == null) return node.Value;
			return Min(node.LeftChild);


		}



		void PreOrder_Traverse(BSTNode<T> node, TextWriter tw)
		{
			if (node == null) return;
			tw.WriteLine(node.Value);

			PreOrder_Traverse(node.LeftChild, tw);
			PreOrder_Traverse(node.RightChild, tw);
			
		}
	}
}
