using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace Retail_Database_Sys
{
    class Receipt
    {
        private List<Item> _Items = new List<Item>();
        public ReadOnlyCollection<Item> Items
        {
            get { return _Items.AsReadOnly(); }
        }
        public void Add(Item item)
        {
            _Items.Add(item);
        }
        public string GetText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Item i in _Items)
                sb.AppendLine(string.Format("{0}", i));
            return sb.ToString();
        }

    }
}

