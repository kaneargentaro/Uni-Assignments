using System;
using System.Diagnostics;
using DataStructures_Algorithms.Week02;

namespace Runner
{
	public class RunnerLecture02 : IRunner
	{
		public RunnerLecture02()
		{
		}

		public void Run(string[] args)
		{

			Stopwatch timer = new Stopwatch();
			timer.Start();
			//Do your operation(s) -- better to repeat this N times (let's say 100) to get a better/stable number
			timer.Stop();
			//timer.Elapsed.TotalMilliseconds/N -- I divide by N because this was the time for N trials
			    

			Vector<int> A = new Vector<int>();

			A.Add(2);
			A.Add(1);
			A.Add(3);
			A.Add(4);
			A.Add(7);
			A.Add(9);
			A.Add(6);
			A.Add(8);


			Vector<int> B = new Vector<int>();

			B.Add(9);
			B.Add(8);
			B.Add(7);
			B.Add(1);
			B.Add(2);
			B.Add(3);
			B.Add(6);
			B.Add(5);

			Vector<int> result = FindIntersection(A, B);

			Console.WriteLine(result.ToString());
		}

		Vector<int> FindIntersection(Vector<int> a, Vector<int> b)
		{
			Vector<int> result = new Vector<int>();


			for (int i = 0; i < a.Count; i++)
			{
				if (b.Contains(a[i]) == true)
					result.Add(a[i]);
			}

			return result;
		}
}
}

