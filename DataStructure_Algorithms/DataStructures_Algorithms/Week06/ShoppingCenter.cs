using System;
using System.Collections.Generic;

namespace DataStructures_Algorithms.Week06
{
    class ShoppingCenter
    {
        Dictionary<string, PointOfInterest> _POIsTable;
        public Dictionary<string, PointOfInterest> POIsTable
        {
            get { return _POIsTable; }
            set { _POIsTable = value; }
        }
        public ShoppingCenter()
        {
            _POIsTable = new Dictionary<string, PointOfInterest>();
            _POIsTable.Add("POI number1", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number2", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number3", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number4", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number5", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number6", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number7", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number8", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number9", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });
            _POIsTable.Add("POI number10", new PointOfInterest { Name = "POI number 1", Description = "jkfdhajfd", Location = "asdfasfa" });

        }
        public string SearchByPOIName(string POIName)
        {
            if (_POIsTable.ContainsKey(POIName))
                return _POIsTable[POIName].ToString();
            else
                return "Not Found";
        }

        public List<PointOfInterest> SearchByService(string ServiceName)
        {
            List<PointOfInterest> result = new List<PointOfInterest>();
            foreach (KeyValuePair<string, PointOfInterest> entry in _POIsTable)
            {
                var currentObject = entry.Value;
                if (currentObject.Services.Contains(ServiceName)) 
                    result.Add(currentObject);
            }
            return result;
        }
    }
}
