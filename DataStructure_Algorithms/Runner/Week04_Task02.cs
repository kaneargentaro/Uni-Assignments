using System;
using DataStructures_Algorithms.Week04;

namespace Runner
{
	public class Week04_Task02 : IRunner
	{
		public Week04_Task02()
		{
		}

		public void Run(string[] args)
		{
			Vector<string> expression = new Vector<string>();
			expression.Add("5"); 
			expression.Add("2");
			expression.Add("3");
			expression.Add("+");
			expression.Add("+");

			RPNCalculator calc = new RPNCalculator(expression);
			Console.WriteLine(string.Format("Input Expression = {0}, and the result = {1}", expression.ToString(), calc.GetResult()));
		}
	}
}

