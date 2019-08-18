using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    class Week10_Task01
    {
        public void Run(string[] args)
        {
            CoinsChanger.AvailableCoins = new int[] { 1, 5, 10, 20, 50 };
            CoinsChanger.GetChangeGreedy(63, Console.Out);

            int num = 5;
            Console.WriteLine(string.Format("Using Recursion: Fibonacci of {0}, is {1} ", num, FamousSequences.GetFibRecursive(5)));
            Console.WriteLine(string.Format("Using DP: Fibonacci of {0}, is {1} ", num, FamousSequences.GetFibRecursive(5)));

        }
    }
}
