using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Week01;
using DataStructures_Algorithms.Utils;
namespace Runner
{
    class Runner01 : IRunner
    {
        public void Run(string[] args)
        {

           

            
            //Note: args[0] is the input file name -- make sure to change it as needed, currently 1H.txt
            if (args.Length < 1 )
            {
                Console.WriteLine("input file name is missing");
                return;
            } 
            Vector<int> vector = null;
            DataSerializer<int>.LoadVectorFromTextFile(args[0], ref vector);

            if(vector == null)
            {
                Console.WriteLine("Failed to load data from input file");
                return;
            }

            //let's check the capacity & count now
            Console.WriteLine("Vector Capacity is {0}", vector.Capacity);
            Console.WriteLine("Vector Count is {0}", vector.Count);

            //let's check how many numbers between 1 and 10000 exist in the input dataset
            //Can you calculate the T(n) & O(n)
            //Can you optimise the running time?
            int count = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (vector.Contains(i) == true)
                    count++;
            }
            Console.WriteLine("{0} numbers between 1 and 10,000 have been used in the dataset (duplicates not counted)", count);

            Console.Read();
        }

    }
}
