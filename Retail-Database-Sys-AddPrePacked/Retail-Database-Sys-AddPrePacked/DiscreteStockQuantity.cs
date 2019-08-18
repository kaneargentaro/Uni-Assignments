using System;
using System.Collections.Generic;

namespace Retail_Database_Sys_AddPrePacked
{
    class DiscreteStockQuantity : StockQuantity
    {
        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
        }
        public DiscreteStockQuantity(int quantity)
        {
            this._Quantity = quantity;
        }
    }
}
