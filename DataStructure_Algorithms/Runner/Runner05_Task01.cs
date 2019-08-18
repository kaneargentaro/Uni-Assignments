using System;
using System.Collections.Generic;
using DataStructures_Algorithms.Week02;
using DataStructures_Algorithms.Week03;
namespace Runner
{
	
	public class Runner05_Task01 : IRunner
	{
		public Runner05_Task01()
		{
		}

		public void Run(string[] args)
		{


			Dictionary<int, Part> myDictionary = new Dictionary<int, Part>();
			myDictionary.Add(1, new Part { PartId = 1, PartName = "a" });
			myDictionary.Add(2, new Part { PartId = 1, PartName = "b" });
			                 
			foreach (KeyValuePair<int, Part> entry in myDictionary)
			{
				Console.WriteLine(string.Format(" key = {0}, and value = {1}", 
				                                entry.Key, entry.Value) ); 
			}

		}
	}
}
