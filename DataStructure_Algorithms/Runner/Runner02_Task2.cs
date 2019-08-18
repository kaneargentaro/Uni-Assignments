using DataStructures_Algorithms.Week02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Runner
{
    class  Runner02_Task2 : IRunner 
    {
        public void Run(string[] args)
        {
            //create vector of parts
            Vector<Part> parts = new Vector<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;
            // Name intentionally left null.
            parts.Add(new Part() { PartId = 1334 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });


            // Write out the parts in the list. This will call the overridden 
            // ToString method in the Part class.
            Console.WriteLine("\nBefore sort:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }


            // Call Sort on the list. This will use the 
            // default comparer, which is the Compare method 
            // implemented on Part.

			PerformanceCounter theCPUCounter  =  new PerformanceCounter("Processor", "% Processor Time", Process.GetCurrentProcess().ProcessName);
			PerformanceCounter theMemCounter  = new PerformanceCounter("Memory", "Available MBytes", Process.GetCurrentProcess().ProcessName);
			parts.Sort();
			var cpu = theCPUCounter.NextValue();
			var memory = theMemCounter.NextValue();
			Console.WriteLine("cpu = " + cpu + ", and memory =" + memory);
            Console.WriteLine("\nAfter sort by part number (Ascending):");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            //Let's do binary search on the sorted list
            int index = parts.BinarySearch(new Part() { PartId = 1434 });
            Console.WriteLine("part 1434 found at index " + index);

            //Sort in reverse order
            parts.Sort(new PartComparer());


            Console.WriteLine("\nAfter sort by part number (Descending):");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }


            //Let's do binary search on the reverse sorted list
            index = parts.BinarySearch(new Part() { PartId = 1634 }, new PartComparer());
            Console.WriteLine("part 1634 found at index " + index);

            Console.Read();
        }
    }
}
