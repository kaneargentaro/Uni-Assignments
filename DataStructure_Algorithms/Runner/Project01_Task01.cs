using System;
using System.Diagnostics;
using DataStructures_Algorithms;
using DataStructures_Algorithms.Project1;

namespace Runner
{
	public class Project01_Task01 : IRunner
	{
		public Project01_Task01()
		{
		}

		public void Run(string[] args)
		{
			if (args.Length < 2)
			{
				Console.WriteLine("Expected two params");
				return;
			}

			string inputFilename = "../../Data/Project01/" + args[0];
			SortingAlgorithm sortingAlgorithm = (SortingAlgorithm) Enum.Parse(typeof(SortingAlgorithm), args[1]);
			string outputFilename = "../../Data/Project01/" + "S_" + args[0];

			Vector<int> vector = null;
			DataSerializer<int>.LoadVectorFromTextFile(inputFilename, ref vector);

			if (vector == null)
			{
				Console.WriteLine("Failed to load data from input file");
				return;
			}

			//let's check the capacity & count now
			Console.WriteLine("Vector Capacity is {0}", vector.Capacity);
			Console.WriteLine("Vector Count is {0}", vector.Count);


			/////
			var averageMemory = 0;
			var totalMemory = 0;
			Stopwatch s = new Stopwatch();
			s.Start();
			long memBefore = 0;
			long memAfter = 0;

			for (int i = 0; i < 5; i++)
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();

				 memBefore = Process.GetCurrentProcess().WorkingSet64;
				vector.Sort(sortingAlgorithm); //This is the same as calling vector.Sort with an ascending order comparer
				 memAfter = Process.GetCurrentProcess().WorkingSet64;
				totalMemory += (int)memAfter - (int)memBefore;
			}
			s.Stop();
			averageMemory = totalMemory / 5;

			Console.WriteLine("execution time = " + s.ElapsedMilliseconds + ", and memory =" + averageMemory / 1024.0);
			/// 

			//Let's sort Vector elements ascending?
			 memBefore = Process.GetCurrentProcess().WorkingSet64;
			GC.Collect();
			 memAfter = Process.GetCurrentProcess().WorkingSet64;

			Console.WriteLine("memory =" + (memAfter - memBefore) / 1024.0);

			memBefore = Process.GetCurrentProcess().WorkingSet64; //100M
			 s = new Stopwatch();
			s.Start();

			vector.Sort(sortingAlgorithm); //This is the same as calling vector.Sort with an ascending order comparer
			//GC clean 80M
			s.Stop();
			memAfter = Process.GetCurrentProcess().WorkingSet64; //102M
			//102-100
			//102 - 80 not very accurate!!!! 
			Console.WriteLine("execution time = " + s.ElapsedMilliseconds + ", and memory =" + (memAfter - memBefore) / 1024.0);

			DataSerializer<int>.SaveVectorToTextFile(outputFilename, vector);

		}
	}
}

