using System;
using System.Collections.Generic;

namespace Retail_Database_Sys
{
    class VolumeStockQuantity : StockQuantity
    {
        private double _Quantity;
        public double Quantity
        {
            get { return _Quantity; }
        }
        public VolumeStockQuantity(double quantity)
        {
            this._Quantity = quantity;
        }
    }
}
