using System;
using System.Collections.Generic;
using DataStructures_Algorithms.Week02;

namespace Runner
{
	public class Lecture3 : IRunner
	{
		public void Run(string[] args)
		{
			Part A = new Part() { PartId = 123, PartName = "abc" };
			Part B = new Part() { PartId = 124, PartName = "abc" };


			switch ( A.CompareTo(B))
			{
				case -1: Console.WriteLine(" A is less than B "); break;
				case 0: Console.WriteLine(" A & B are equal"); break;
				case 1: Console.WriteLine(" A is greater than B "); break;
			}

		}
	}
}

