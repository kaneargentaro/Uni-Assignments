using System;
using QuickGraph;

namespace DataStructures_Algorithms
{
	public class GraphEdge<T> : IEdge<T>
	{
		public T Source { get; set; }
		public T Target { get; set; }
		public string Description { get; set; }
		public double Distance { get; set; }

		public override string ToString()
		{
			var str = string.Format("From: {0}, To: {1}, Description:{2}, Distance:{3}",
			                        Source, Target, (Description != null? Description : "No Description"), (Distance > 0 ? Distance.ToString() : "No Distance"));

			return str;
			
		}
		public GraphEdge()
		{
		}

		public GraphEdge(T v1, T v2)
		{
			this.Source = v1;
			this.Target = v2;
		}
	}
}
