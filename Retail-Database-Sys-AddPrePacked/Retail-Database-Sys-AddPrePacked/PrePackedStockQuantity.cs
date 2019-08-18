using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_Database_Sys_AddPrePacked
{
    class PrePackedStockQuantity : StockQuantity
    {
        private double _Quantity;
        public double Quantity
        {
            get { return _Quantity; }
        }
        public PrePackedStockQuantity(double quantity)
        {
            this._Quantity = quantity;
        }
    }
}
