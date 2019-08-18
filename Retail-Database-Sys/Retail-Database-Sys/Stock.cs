using System;

namespace Retail_Database_Sys
{
    abstract class Stock
    {
        private Line _Line;
        public Line Line
        {
            get { return _Line; }
        }
        public Stock(Line line)
        {
            this._Line = line;
        }

        public abstract void AdjustStock(StockQuantity quantity);
        public abstract bool Purchase(StockQuantity quantity, out Item item);
        public abstract void Restock();

    }
}
