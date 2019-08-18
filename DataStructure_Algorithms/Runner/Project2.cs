using System;
using System.Threading;
using DataStructures_Algorithms;

namespace Runner
{
	public class Project2 : IRunner
	{
		int numberOfVisitors = 1;
		int numberOfPOIs = 1;
		Random rn = new Random();
		BackendService backendService = null;
		Thread[] visitors = null;

		public void Run(string[] args)
		{
			if (args.Length < 1)
			{
				Console.WriteLine("Error, expected one argument: number of visitors");
				return;
			}
			numberOfVisitors = int.Parse(args[0]);

			//create the backend servie, you need to 
			backendService = new BackendService();
			backendService.Init();
			numberOfPOIs = backendService.NumberOfPOIs;

			LaunchThreads();


			WaitUntilAllThreadsComplete();
			backendService.ShoppingCenterIsOpen = false;
			Console.WriteLine("Shopping center is now closed!");

		}

		void LaunchThreads()
		{
			visitors = new Thread[numberOfVisitors];
			for (int i = 0; i < numberOfVisitors; i++)
			{
				visitors[i] = new Thread((obj) => this.Walk(obj));

			}
			for (int i = 0; i < numberOfVisitors; i++)
			{
				visitors[i].Start(i);
			}
		}

		private void WaitUntilAllThreadsComplete()
		{
			foreach (Thread machineThread in visitors)
			{
				
				machineThread.Join();
			}
		}

		void Walk(object obj)
		{
			int start = 0, destination = 0;
			POI startPOI = null, destinationPOI = null, currentPOI = null;

			start = rn.Next() % numberOfPOIs;
			destination = rn.Next() % numberOfPOIs;
			while (destination == start) { destination = rn.Next() % numberOfPOIs; }

			int i = 0;
			foreach (string key in backendService.POIsTable.Keys)
			{
				if (i == start) startPOI = backendService.POIsTable[key];
				if( i == destination) destinationPOI = backendService.POIsTable[key];
				if( startPOI != null && destinationPOI != null) break;
				i++;
			}

			string deviceID = ("MobileDevice" + (int)obj);
			if (backendService.FindPOI(deviceID, startPOI, destinationPOI) == false)
			{
				Console.WriteLine(string.Format(" {0}, no path found from {1} to {2}", deviceID, startPOI.POIName, destinationPOI.POIName));
				return;
			}

			Console.WriteLine(string.Format(" {0}, path found from {1} to {2}", deviceID, startPOI.POIName, destinationPOI.POIName));
			currentPOI = startPOI;
			while(currentPOI != destinationPOI)
				{
						backendService.LocationServiceQueue.Enqueue(new DeviceMessage
						{
							DeviceId = deviceID,
							CurrentPOI = currentPOI,
							Timestamp = DateTime.Now
						});
						

						while (backendService.ActiveDevicesTable[deviceID].CurrentPOI == null || currentPOI == backendService.ActiveDevicesTable[deviceID].CurrentPOI) {}
						Console.WriteLine(deviceID + " " + currentPOI.POIName + " ---> " + backendService.ActiveDevicesTable[deviceID].CurrentPOI.POIName);
						
						Thread.Sleep(1000);
						currentPOI = backendService.ActiveDevicesTable[deviceID].CurrentPOI;
						
				}
			Console.WriteLine(deviceID + " arrived!");


		}
}
}
