using System;
using DataStructures_Algorithms.Week04;
namespace Runner
{
	public class Week04_Task1 : IRunner
	{

		public void Run(string[] args)
		{
			Stack<int> stack = new Stack<int>();
			stack.Push(4);
			Console.WriteLine("4 pushed, stack count = " + stack.Count);
			stack.Push(6);
			Console.WriteLine("6 pushed, stack count = " + stack.Count);
			stack.Push(8);
			Console.WriteLine("8 pushed, stack count = " + stack.Count);
			int v = stack.Peek();
			Console.WriteLine("Stack Peek= " + v);
			v = stack.Pop();
			Console.WriteLine("value poped = " + v);
			Console.WriteLine("=======================================");


			Queue<int> queue = new Queue<int>();
			queue.Enque(4);
			Console.WriteLine("4 enqued, queue count = " + queue.Count);
			queue.Enque(6);
			Console.WriteLine("6 enqued, queue count = " + queue.Count);
			queue.Enque(8);
			Console.WriteLine("8 enqued, queue count = " + queue.Count);
			v = queue.Deque();
			Console.WriteLine("value dequed = " + v);

			Console.ReadKey();

		}
	}
}

