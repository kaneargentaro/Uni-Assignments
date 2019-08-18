using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures_Algorithms.Week03
{
	public class ListEnumerator<T> : IEnumerator<T>
	{
		LinkedList<T> list;
		Node<T> head;
		T current = default(T);
		public ListEnumerator(LinkedList<T> LinkedList)
		{
			list = LinkedList;
			head = list.Head;
			current = default(T);
		}
		//Advances the enumerator to the next element of the collection
		//adjust your pointer to the next node, and adjust current field accordingly
		//if no elements remaining (head.next == null) you should return false
		//otherwise advance your head to the next node
		public bool MoveNext()
		{
			//TODO: MoveNext - Please add your MoveNext implementation here

			if (head == null) return false;

			current = head.Value;
			head = head.Next; 
			return true;

		}

		public void Reset()
		{
			head = list.Head;
			current = default(T);
		}
		public T Current
		{
			get
			{
				return current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return current;
			}
		}

		public void Dispose()
		{
			
		}



	}
}

