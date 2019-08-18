using System;
using System.Collections.Generic;
using DataStructures_Algorithms;
using DataStructures_Algorithms.Week02;

namespace Runner
{
	public class Runner05_lecture1 : IRunner
	{
		public Runner05_lecture1()
		{
		}

		public void Run(string[] args)
		{
			Part part1 = new Part { PartId = 1, PartName = "hi 1" };
			Part part2 = new Part { PartId = 2, PartName = "hi 2" };
			Part part3 = new Part { PartId = 1, PartName = "hi 1" };

			Dictionary<Part, int> partBalance = new Dictionary<Part, int>();
			partBalance.Add(part1, 20);
			partBalance.Add(part2 , 30);
			partBalance.Add(part3, 50);

			Console.WriteLine(part1.GetHashCode() + " " + part3.GetHashCode());




		}
	}
}
