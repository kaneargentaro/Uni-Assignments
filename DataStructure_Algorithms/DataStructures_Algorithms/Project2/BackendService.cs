using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using QuickGraph;
using QuickGraph.Algorithms.Observers;

namespace DataStructures_Algorithms
{
	public class BackendService
	{
		public int NumberOfPOIs 
		{ 
			get { return POIsTable.Count; }

		}

		public bool ShoppingCenterIsOpen { get; set; }

        public Dictionary<string, POI> POIsTable = null;
        BidirectionalGraph<POI, Edge<POI>> POIsGraph = null;
        public ConcurrentDictionary<string, NavigationDetails> ActiveDevicesTable = null;
        public ConcurrentQueue<DeviceMessage> LocationServiceQueue = new ConcurrentQueue<DeviceMessage>(); 



		public bool FindPOI(string DeviceId, POI Source, POI Target)
		{
			Stack<Edge<POI>> path = GetShortestPath(Source, Target);
			if (path == null) return false;
       
            //You may want to do it manually? then check if the key does not exist using ContainsKey, then call TryAdd
            //and if it does exist, then do ActiveDevicesTable[deviceId] = your new NavigationDetails object 

            var nav = new NavigationDetails { CurrentPOI = Source, DestinationPOI = Target, PathToDestination = path };
            ActiveDevicesTable.AddOrUpdate(DeviceId, nav, (k, v) => nav);
            ActiveDevicesTable.TryAdd(DeviceId, new NavigationDetails { CurrentPOI = Source, });

			return true;

		}
		public BackendService()
		{

        }
		public void Init()
		{
            //Initialise your POIsTable
            POIsTable = new Dictionary<string, POI>();
            LocationServiceQueue = new ConcurrentQueue<DeviceMessage>();
            //Intialise your POIsGraph
            POIsGraph = new BidirectionalGraph<POI, Edge<POI>>();
            //TODO: Add a list of POI locations (at least 10 POIs) to the POIsTable & to the POIsGraph
            //Many lines here for POIs
            POIsTable.Add("POI1", new POI { POIName = "Myer", POIDescription = "Clothing Super Store" });
            POIsTable.Add("POI2", new POI { POIName = "JB HI FI", POIDescription = "Entertainment and Electronics Store" });
            POIsTable.Add("POI3", new POI { POIName = "Target", POIDescription = "General Store" });
            POIsTable.Add("POI4", new POI { POIName = "Big W", POIDescription = "General Store" });
            POIsTable.Add("POI5", new POI { POIName = "Kmart", POIDescription = "General Store" });
            POIsTable.Add("POI6", new POI { POIName = "Coles", POIDescription = "Supermarket" });
            POIsTable.Add("POI7", new POI { POIName = "Safeway", POIDescription = "Supermarket" });
            POIsTable.Add("POI8", new POI { POIName = "The Reject Shop", POIDescription = "General Store" });
            POIsTable.Add("POI9", new POI { POIName = "Eb Games", POIDescription = "Gaming Store" });
            POIsTable.Add("POI10", new POI { POIName = "$2 Shop", POIDescription = "General Store" });

            var x = POIsTable["POI1"];

            POIsGraph.AddVertex(POIsTable["POI1"]);
            POIsGraph.AddVertex(POIsTable["POI2"]);
            POIsGraph.AddVertex(POIsTable["POI3"]);
            POIsGraph.AddVertex(POIsTable["POI4"]);
            POIsGraph.AddVertex(POIsTable["POI5"]);
            POIsGraph.AddVertex(POIsTable["POI6"]);
            POIsGraph.AddVertex(POIsTable["POI7"]);
            POIsGraph.AddVertex(POIsTable["POI8"]);
            POIsGraph.AddVertex(POIsTable["POI9"]);
            POIsGraph.AddVertex(POIsTable["POI10"]);

            //TODO: Add edges to your POIsGraph (20 edges? more? up to you)
            //Many lines here for edge
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI1"], Target = POIsTable["POI2"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI2"], Target = POIsTable["POI3"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI3"], Target = POIsTable["POI4"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI4"], Target = POIsTable["POI5"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI5"], Target = POIsTable["POI6"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI6"], Target = POIsTable["POI7"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI7"], Target = POIsTable["POI8"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI8"], Target = POIsTable["POI9"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI9"], Target = POIsTable["POI10"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI10"], Target = POIsTable["POI7"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI1"], Target = POIsTable["POI3"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI1"], Target = POIsTable["POI4"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI1"], Target = POIsTable["POI5"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI1"], Target = POIsTable["POI6"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI1"], Target = POIsTable["POI7"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI1"], Target = POIsTable["POI8"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI1"], Target = POIsTable["POI9"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI8"], Target = POIsTable["POI3"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI7"], Target = POIsTable["POI5"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI4"], Target = POIsTable["POI6"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI5"], Target = POIsTable["POI8"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI6"], Target = POIsTable["POI9"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI7"], Target = POIsTable["POI10"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI9"], Target = POIsTable["POI3"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI3"], Target = POIsTable["POI7"] });
            POIsGraph.AddEdge(new Edge<POI> { Source = POIsTable["POI4"], Target = POIsTable["POI6"] });

            //Initialise your ActiveDevicesTable, this is an empty table - to be filled automatically
            ActiveDevicesTable = new ConcurrentDictionary<string, NavigationDetails>();



			//Now let's open the shopping center and create a queue handling thread.
			//You do not need to modify this code
			ShoppingCenterIsOpen = true;
			Thread queueHandler = new Thread(() => this.WatchLocationServiceQueue());
			queueHandler.Start();
		}
		void WatchLocationServiceQueue()
		{
			DeviceMessage message = null;
			while (ShoppingCenterIsOpen == true && LocationServiceQueue.TryDequeue(out message) == false) { }
			if (ShoppingCenterIsOpen == false) return;

			//TODO: Complete the WatchLocationServiceQueue method
			//At this point (line), you have a message you retrieved from the queue - this is the message object
			//If the message is sent by a known device (exists in the ActiveDevicesTable, then we need to update route & give directions
			//Otherwise -else skip the message, in a future version, you may track people movement in the shoppping center (not now)
			//If the device known - exists in the ActiveDevicesTable, then we need to check if there is any step left in 
			//the PathToDestination stack - you can use count > 0
			//If yes then we need to Pop an edge from the stack
			// and then set the CurrentPOI of this device entry in the ActiveDevicesTable 
			// to either Source or Target (based on route direction)
			//This step is important, because I wait for the value of the CurrentPOI to change 
			//in the Walk method (see the Runner class)
			//To tell the user that there is a new direction 
            if (ActiveDevicesTable.ContainsKey(message.DeviceId) == true)
            {
                if (ActiveDevicesTable[message.DeviceId].PathToDestination.Count > 0)
                {
                    var edge = ActiveDevicesTable[message.DeviceId].PathToDestination.Pop();
                    var current = ActiveDevicesTable[message.DeviceId].CurrentPOI;
                    if (edge.Source == current)
                        ActiveDevicesTable[message.DeviceId].CurrentPOI = edge.Target;
                    else
                        ActiveDevicesTable[message.DeviceId].CurrentPOI = edge.Source;
                }
            }


			//This will make sure that we process the next item in the LocationServiceQueue
			WatchLocationServiceQueue();
		}


		public Stack<Edge<POI>> GetShortestPath(POI Source, POI Target)
		{
			QuickGraph.Algorithms.ShortestPath.DijkstraShortestPathAlgorithm<POI, Edge<POI>> algo =
				new QuickGraph.Algorithms.ShortestPath.DijkstraShortestPathAlgorithm<POI, Edge<POI>>(POIsGraph, (Edge<POI> arg) => arg.Distance);


			// creating the observer & attach it
			var vis = new VertexPredecessorRecorderObserver<POI, Edge<POI>>();
			vis.Attach(algo);

			// compute and record shortest paths
			algo.Compute(Target);

			// vis can create all the shortest path in the graph
			IEnumerable<Edge<POI>> path = null;
			vis.TryGetPath(Source, out path);
			Stack<Edge<POI>> pathStack = new Stack<Edge<POI>>();
			if (path == null) return null;

			foreach (Edge<POI> e in path)
				pathStack.Push(e);
			return pathStack;
		}

			   
		
	}
}
