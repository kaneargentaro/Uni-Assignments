using System;

namespace Retail_Database_Sys
{
    class Item
    {
        private int _Quantity;
        private string _Description;
        private double _Weight;
        public int Quantity
        {
            get { return _Quantity;}
        }
        public string Description
        {
            get { return _Description; }
        }
        public double Weight
        {
            get { return _Weight; }
        }

        public Item(int Quantity, string Description, double Weight)
        {
            this._Quantity = Quantity;
            this._Description = Description;
            this._Weight = Weight;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} ({2} kg)", Quantity, Description, Weight);
        }
    }
}
