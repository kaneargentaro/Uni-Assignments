using System;
namespace DataStructures_Algorithms.Week04
{
	public class Node<T>
	{
		public T Value { get; set; }
		public Node<T> Next { get; set;}
		public Node(T nodeValue)
		{
			Value = nodeValue;
		}
		public Node(T nodeValue, Node<T> nextNode)
		{
			Value = nodeValue;
			Next = nextNode;
		}


	}
}

