using System;
using DataStructures_Algorithms.Project1;

namespace DataStructures_Algorithms
{
	/// <summary>
	/// This is a generic implementation of the mathematical set class
	/// This class implements 10 key set operations including membership, subset, superset, powerset and many more 
	/// </summary>
	public class SetClass<T>
	{
		public Vector<T> Data { get; set;}


		/// <summary>
		/// This method checks if a given element belongs to the set of elements or not
		/// </summary>
		/// <param name="element">Element to check for membership</param>
		/// <returns><c>true</c>, if the element belongs to the set,<c>false</c>otherwise</returns>
		public bool Membership(T element) {
			//Any implementation that checks if the given element exists in the current set data.
			//Here we just use contains from the vector class - was developed in week1
			return Data.Contains(element);

		}



		/// <summary>
		/// This method checks if the current set is contained in an input set B
		/// </summary>
		/// <returns><c>true</c>, if this set is a subset of input set B,<c>false</c> otherwise.</returns>
		/// <param name="B">The input set to compare with</param>
		public bool IsSubsetOf(SetClass<T> B) {
			//any implementation that checks if every single element in A exists in B
			var count = Data.Count;
			for (int i = 0; i < count; i++)
				if (B.Data.Contains(Data[i]) == false) return false;
			return true;
		}

		/// <summary>
		/// This method checks if the current set contains all elements in an input set B
		/// </summary>
		/// <returns><c>true</c>,if this set is a superset of input set B, <c>false</c> otherwise.</returns>
		/// <param name="B">B.</param>
		public bool IsSupersetOf(SetClass<T> B) 
		{
			//any implementation that checks if every single element in B exists in A
			var count = B.Data.Count;
			for (int i = 0; i < count; i++)
				if (Data.Contains(B.Data[i]) == false) return false;
			return true;
		}

		/// <summary>
		/// This method returns all possible subset of the current set
		/// </summary>
		public SetClass<SetClass<T>> Powerset()
		{
			//Any implementation that can enumerate all possible subsets, here is an example
			//there is another one that uses Math.Pow method

			int n = 1 << Data.Count; //this is one way to get 2 to the power of n using left shift operation
			SetClass<SetClass<T>> result = 
				new SetClass<SetClass<T>>(new Vector<SetClass<T>>());

			//loops on the number of possible subsets, and try to construct the corresponding subset
			for (int i = 0; i < n; i++)
			{
				SetClass<T> subset = new SetClass<T>(new Vector<T>());

				//subsetIndex is the index of the subset in the list of possible subsets - 0,1,2,..
				// elementIndex is the index of the current set elements to add to the subset
				for (int subsetIndex = i, elementIndex = 0; subsetIndex != 0; subsetIndex /= 2, elementIndex++)
				{
					//if the corresponding bit is equal to 1, 
					//it means that this set element should be added to the curret subset, 
					//based on its index
					if ( (subsetIndex & 1) != 0) 
						subset.Data.Add(Data[elementIndex]);
				}
				result.Data.Add(subset);
			}
			return result;
		}
			

		/// <summary>
		/// This method finds the intersection between current set and input set B
		/// </summary>
		/// <returns>a SetClass object that contains all common elements between this set and set B</returns>
		/// <param name="B">the other set to find intersection with</param>
		public SetClass<T> IntersectionWith(SetClass<T> B) {
			//Any implementation that gets common elements between this set and set B

			SetClass<T> result = new SetClass<T>(new Vector<T>());
			var count = Data.Count;
			for (int i = 0; i < count; i++)
			{
				if (B.Data.Contains(Data[i]) == true)
				{
					result.Data.Add(Data[i]);
				}
			}
			return result;		
		}

		/// <summary>
		/// This method returns all elements in the current set as well as the input set B without duplicates
		/// </summary>
		/// <returns> a SetClass object that contains all elements in both A and B</returns></returns>
		/// <param name="B">the other set to find union with</param>
		public SetClass<T> UnionWith(SetClass<T> B) 
		{
			//Any implementation that get all elements in A and B - no duplicates

			SetClass<T> result = new SetClass<T>(new Vector<T>());

			//Add all elements in current set
			var count = Data.Count;
			for (int i = 0; i < count; i++)
				result.Data.Add(Data[i]);

			//Add new elements from set B
			count = B.Data.Count;
			for (int i = 0; i < count; i++)
				if (result.Data.Contains(B.Data[i]) == false)
					result.Data.Add(B.Data[i]);

			return result;
		}

		/// <summary>
		/// This method returns the elements in current set but not in set B
		/// </summary>
		/// <returns> a SetClass object that contains all elements in current set, but not in B</returns></returns>
		/// <param name="B">the other set to find difference with</param>
		public SetClass<T> Difference(SetClass<T> B)
		{
			SetClass<T> result = new SetClass<T>(new Vector<T>());

			var count = Data.Count;
			for (int i = 0; i < count; i++)
				if (B.Data.Contains(B.Data[i]) == false)
					result.Data.Add(Data[i]);

			return result;
		}

		/// <summary>
		/// This method find elements in current set (set A), but not in input set B AND
		/// elements in input set B, but not in current set.
		/// </summary>
		/// <returns>a SetClass object that contains elements in A but not in B, and elements in B but not in A</returns>
		/// <param name="B">B.</param>
		public SetClass<T> SymmetricDifference(SetClass<T> B) 
		{

			//Any implementation that gets (A - B) union (B - A)
			return this.Difference(B).UnionWith(B.Difference(this));
		}

		/// <summary>
		/// This method finds elements in U (universal set - superset that has all elements in A and more) but not in A
		/// </summary>
		/// <returns>a SetClass object that contains elements in U but not in A</returns>
		/// <param name="U">The universal set</param>
		public SetClass<T> Complement(SetClass<T> U)
		{
			return U.Difference(this);
		}

		/// <summary>
		/// This method returns the cartesian product of current set (set A) and input set (set B)
		/// </summary>
		/// <returns>A SetClass object that contains pairs (a, b) of elements from A, and B respectively</returns>
		/// <param name="B">B.</param>
		/// <typeparam name="T2">the other set to find the cartesian product</typeparam>
		public SetClass<Tuple<T, T2>> CartesianProduct<T2>(SetClass<T2> B)
		{
			
			SetClass<Tuple<T, T2>> result =
				new SetClass<Tuple<T, T2>>(new Vector<Tuple<T, T2>>());

			var aCount = Data.Count;
			var bCount = B.Data.Count;

			for (int i = 0; i < aCount; i++)
			{
				for (int j = 0; j < bCount; j++)
				{
					result.Data.Add(new Tuple<T, T2>(Data[i], B.Data[j]));

				}			
			}
			return result;
		}


		/// <summary>
		/// This is class constructor
		/// </summary>
		/// <param name="data">the vector object to store data in, or with data pre-loaded in it</param>
		public SetClass(Vector<T> data)
		{
			Data = data;
		}

		public override string ToString()
		{
			string str = "{";
			if(Data.Count > 0)
				str += Data.ToString();
			str += "}";

			return str;
		}
	}
}

