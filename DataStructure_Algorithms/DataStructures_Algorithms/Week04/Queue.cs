using System;
using System.Collections.Generic;

namespace DataStructures_Algorithms.Week04
{
	public class Queue<T>
	{
		IList<T> data = null;
		public Queue()
		{
			data = new LinkedList<T>();	
		}
		public Queue(IList<T> datastore)
		{
			data = datastore;
		}

		public void Enque(T element)
		{
			//TODO: Implement Enque method
			data.Add(element);
		}
		public T Deque()
		{
			//TODO: Implement Deque method 
			if (data.Count <= 0) throw new InvalidOperationException("Queue is empty");
			var item = data[0];
			data.RemoveAt(0);
			return item;
		}

		public int Count { get { return data.Count; } }
	}
}


