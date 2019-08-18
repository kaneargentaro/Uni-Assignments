using System;
using DataStructures_Algorithms;
using DataStructures_Algorithms.Project1;

namespace Runner
{
	public class Project01_Task2 : IRunner
	{
		public Project01_Task2()
		{
		}

		public void Run(string[] args)
		{
			SetClass<SetClass<int>> ps = new SetClass<SetClass<int>>(new Vector<SetClass<int>>());
			ps.Data.Add(new SetClass<int>(new Vector<int>()));
			ps.Data[0].Data.Add(1);
			ps.Data[0].Data.Add(2);

			ps.Data.Add(new SetClass<int>(new Vector<int>()));
			ps.Data[1].Data.Add(3);
			ps.Data[1].Data.Add(4);

			ps.Data.Add(new SetClass<int>(new Vector<int>()));
			ps.Data[2].Data.Add(5);

			string s = ps.ToString();


			Vector<Tuple<int, int>> abc = new Vector<Tuple<int, int>>();
			abc.Add(new Tuple<int, int>(3, 4));

			if (args.Length < 2)
			{
				Console.WriteLine("Expected at least two params");
				return;
			}

			string opName = args[0];
			OperationEnum op = (OperationEnum) Enum.Parse(typeof(OperationEnum), opName);

			string setAPath = "../../Data/Project01/" + args[1];
			SetClass<int> setB = null;
			int element = 0;

			if (op == OperationEnum.MEMBERSHIP)
				element = int.Parse(args[2]);
			else if (args.Length == 3)
			{
				string setBPath = "../../Data/Project01/" + args[2];
				Vector<int> setBData = null;
				DataSerializer<int>.LoadVectorFromTextFile(setBPath, ref setBData);

				if (setBData == null)
				{
					Console.WriteLine("Failed to load data from input file");
					return;
				}


				setB = new SetClass<int>(setBData);

			}


			Vector<int> setAData = null;
			DataSerializer<int>.LoadVectorFromTextFile(setAPath, ref setAData);

			if (setAData == null)
			{
				Console.WriteLine("Failed to load data from input file");
				return;
			}
			SetClass<int> setA = new SetClass<int>(setAData);



			switch (op)
			{


				case OperationEnum.CARTESIAN:
					Console.WriteLine(
						string.Format("Cartesian of SetA- {0}, Set B- {1}, is = {2} ", 
						              setA.Data.ToString(), 
						              setB.Data.ToString(), 
						              setA.CartesianProduct<int>(setB).Data.ToString()
						             )
				); break;

				case OperationEnum.MEMBERSHIP: 
					Console.WriteLine(string.Format("Check membership of {0}, is {1}", element, setA.Membership(element))); break;
				case OperationEnum.SUBSET: 
					Console.WriteLine(string.Format("Check subset of {0} in {1}, and result = {2}", 
				                                                           setA.Data.ToString(), 
				                                                           setB.Data.ToString(), 
				                                                           setA.IsSubsetOf(setB)
																			)
															); break;

				case OperationEnum.INTERESECTION:
					var setC = setA.IntersectionWith(setB);
					Console.WriteLine(string.Format("Interesection of A- {0}, with B- {1} is {2}",
													setA.Data.ToString(),
					                                setB.Data.ToString(),
					                                setC.Data.ToString()

					                               )); 
					
					DataSerializer<int>.SaveVectorToTextFile("f1.txt", setC.Data);   break;
				case OperationEnum.SUPERSET:
					Console.WriteLine(string.Format("Check power of {0}, result = {1}",
					                                setA.Data.ToString(),
																		
					                                setA.Powerset()
																			
				)); break;
			}

		}
	}
}

