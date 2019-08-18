using System;
namespace DataStructures_Algorithms.Week04
{
	public class RPNCalculator
	{
		Stack<int> operands = new Stack<int>();


		public RPNCalculator(Vector<string> expression)
		{
			int _operand;
			char _operator;
			for (int i = 0; i < expression.Count; i++)
			{
				if (int.TryParse(expression[i], out _operand) == true)
				{
					operands.Push(_operand);
				}
				else if (char.TryParse(expression[i], out _operator) == true)
				{
					switch (_operator)
					{
						case '+': Add(); break;
						case '-': Subtract(); break;
						case '*': Multiple(); break;
						case '/': Divide(); break;
					}
				}
				else
					throw new Exception("Invald data type");
			}
		}

		public int GetResult()
		{
			if (operands.Count == 0) throw new Exception("No value available");
			return operands.Pop();
		}

		void Divide()
		{
			//TODO: Implement Divide method
		}

		void Multiple()
		{
			//TODO: Implement Multiple method
		}

		void Subtract()
		{
			//TODO: Implement Subtract method

		}

		void Add()
		{
			if(operands.Count < 2) throw new Exception("no enough operands");
			int op1 = operands.Pop();
			int op2 = operands.Pop();
			operands.Push(op1 + op2);

		}
}
}

