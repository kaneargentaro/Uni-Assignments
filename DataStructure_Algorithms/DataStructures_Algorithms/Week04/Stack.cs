using System;
using System.Collections.Generic;

namespace DataStructures_Algorithms.Week04
{
	public class Stack<T> 
	{
		IList<T> data = null;
		public Stack()
		{
			data = new LinkedList<T>();
		}
		public Stack(IList<T> datastore)
		{
			data = datastore;
		}

		public void Push(T element) 
		{
			data.Insert(0, element);
		}
		public T Pop()
		{
			if (data.Count <= 0) throw new InvalidOperationException("Stack is empty");
			var item = data[0];
			data.RemoveAt(0);
			return item;

		}
		public T Peek()
		{
			if (data.Count <= 0) throw new InvalidOperationException("Stack is empty");
			var item = data[0];
			return item;
		}
		public int Count { get { return data.Count; } }
	}
}


