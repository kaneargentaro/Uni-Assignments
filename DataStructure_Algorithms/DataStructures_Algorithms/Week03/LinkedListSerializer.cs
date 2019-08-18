using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Week03
{
    public class LinkedListSerializer<T> where T : IConvertible
    {
		public static void Serialise(string path, LinkedList<T> linkedList)
        {
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, linkedList);
            }
        }
		public void Deserialise(string path, ref LinkedList<T> linkedList)
        {

            using (Stream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
				linkedList = ( LinkedList<T>)bin.Deserialize(stream);

            }
        }

		public static void LoadLinkedListFromTextFile(string path, ref LinkedList<T> linkedList)
        {

			linkedList = new LinkedList<T>();
            string line = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    //This would work only for primitive types
					linkedList.Add((T)Convert.ChangeType(line, typeof(T)));
                }
            }
        }

        public static void SaveLinkedListToTextFile(string path, LinkedList<T> linkedList)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
				var count = linkedList.Count;
                for (int i = 0; i < count ; i++)
                {
					sw.WriteLine(linkedList[i]);              
                }
            }
        }

    }
}
