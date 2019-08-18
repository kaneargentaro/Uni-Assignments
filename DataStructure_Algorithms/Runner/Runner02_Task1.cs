using DataStructures_Algorithms.Week02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Runner
{
    class  Runner02_Task1 : IRunner 
    {
        public void Run(string[] args)
        {
            //Note: args[0] is the input file name -- make sure to change it as needed, currently 1H.txt
            if (args.Length < 1)
            {
                Console.WriteLine("input file name is missing");
                return;
            }
            Vector<int> vector = null;

            string inputFileName = args[0];
            string outputFileName = "S_1H.txt";
            DataSerializer<int>.LoadVectorFromTextFile(inputFileName, ref vector);

            if (vector == null)
            {
                Console.WriteLine("Failed to load data from input file");
                return;
            }

            //let's check the capacity & count now
            Console.WriteLine("Vector Capacity is {0}", vector.Capacity);
            Console.WriteLine("Vector Count is {0}", vector.Count);


            //Let's sort Vector elements ascending?
           
			var memBefore = Process.GetCurrentProcess().WorkingSet64;
			Stopwatch s = new Stopwatch();
			s.Start();
			vector.Sort();
			s.Stop();
			var memAfter = Process.GetCurrentProcess().WorkingSet64;

			Console.WriteLine("cpu = " + s.ElapsedMilliseconds + ", and memory =" + (memAfter - memBefore)/1024.0 + " memory before =" + memBefore + ", and memory after = " + memAfter);


            Console.WriteLine("Data has been sorted");
            DataSerializer<int>.SaveVectorToTextFile(outputFileName, vector);
            Console.WriteLine( string.Format("Data has been stored to {0}", outputFileName));




            //Now can we try to sort the vector elements descending?


            Console.Read();
        }
    }
}
