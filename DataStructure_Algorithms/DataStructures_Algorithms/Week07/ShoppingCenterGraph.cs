using System;
using System.Collections.Generic;
using QuickGraph;

namespace DataStructures_Algorithms
{
    public class City
    {
        public string CityName { get; set; }
        public int Pop { get; set; }
        public List<string> Places { get; set; }
    }
    public class ShoppingCenterGraph
	{

        BidirectionalGraph<PointOfInterest, GraphEdge<PointOfInterest>> POIsGraph
            = new BidirectionalGraph<PointOfInterest, GraphEdge<PointOfInterest>>();

        public ShoppingCenterGraph()
		{

            var poi1 = new PointOfInterest { Name = "Target", Description = "...", Location = "abc" };

            POIsGraph.AddVertex(poi1);

            var poi2 = new PointOfInterest { Name = "Target2", Description = "...", Location = "abc2" };

            POIsGraph.AddVertex(poi2);

            var poi3 = new PointOfInterest { Name = "Target3", Description = "...", Location = "abc3" };

            POIsGraph.AddVertex(poi3);

            var poi4 = new PointOfInterest { Name = "Target4", Description = "...", Location = "abc4" };

            POIsGraph.AddVertex(poi4);

            var poi5 = new PointOfInterest { Name = "Target5", Description = "...", Location = "abc5" };

            POIsGraph.AddVertex(poi5);

            var poi6 = new PointOfInterest { Name = "Target6", Description = "...", Location = "abc6" };

            POIsGraph.AddVertex(poi6);

            var poi7 = new PointOfInterest { Name = "Target7", Description = "...", Location = "abc7" };

            POIsGraph.AddVertex(poi7);

            var poi8 = new PointOfInterest { Name = "Target8", Description = "...", Location = "abc8" };

            POIsGraph.AddVertex(poi8);

            var poi9 = new PointOfInterest { Name = "Target9", Description = "...", Location = "abc9" };

            POIsGraph.AddVertex(poi9);

            var poi10 = new PointOfInterest { Name = "Target10", Description = "...", Location = "abc10" };

            POIsGraph.AddVertex(poi10);


            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi1, Target = poi2, Description = "aaaa", Distance = 5 });
            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi2, Target = poi3, Description = "bbbb", Distance = 15 });
            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi3, Target = poi4, Description = "cccc", Distance = 25 });
            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi4, Target = poi5, Description = "dddd", Distance = 35 });
            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi5, Target = poi6, Description = "eeee", Distance = 45 });
            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi6, Target = poi7, Description = "ffff", Distance = 55 });
            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi7, Target = poi8, Description = "gggg", Distance = 65 });
            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi8, Target = poi9, Description = "hhhh", Distance = 75 });
            POIsGraph.AddEdge(new GraphEdge<PointOfInterest> { Source = poi9, Target = poi10, Description = "iiii", Distance = 85 });
        


        }
        
		public List<PointOfInterest> FindPossibleRoutesFrom(string POIName)
		{

			foreach (string str in POIsGraph.Vertices)
            {
                if (str == POIName)
                {

                }
            }

			

		}


    }
}
