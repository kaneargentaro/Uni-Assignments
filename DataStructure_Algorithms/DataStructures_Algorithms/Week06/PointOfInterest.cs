using System;
using System.Collections.Generic;

namespace DataStructures_Algorithms
{
	public class PointOfInterest
	{
		public string Name { get; set; }
		public string Description { get; set;}
		public string Location { get; set; }
		public List<string> Services { get; set; }
		 
		public PointOfInterest()
		{
		}
		public override string ToString()
		{
			string serviceStr = "";
			foreach (string srv in Services)
				serviceStr += " " + srv;
			return string.Format("[PointOfInterest: Name={0}, Description={1}, Location={2}, services=[{3}]]", Name, Description, Location, serviceStr);
		}
	}
}
