using System;
using System.Collections.Generic;

namespace Retail_Database_Sys_AddPrePacked
{
    class PrePackedStock : Stock
    {
        private double calculateweight = 250;
        private double _StoredStock;
        private double _ShelfStock;
        private double _DefaultWeight;

        public double StoredStock
        {
            get { return _StoredStock; }
        }
        public double ShelfStock
        {
            get { return _ShelfStock; }
        }
        public double DefaultWeight
        {
            get { return _DefaultWeight; }
        }

        public PrePackedStock(Line line, double defaultweight) : base(line)
        {
            _DefaultWeight = defaultweight;
            _ShelfStock = 0;
            _StoredStock = 0;
        }

        public override bool Purchase(StockQuantity quantity, out Item item)
        {
            PrePackedStockQuantity quan = quantity as PrePackedStockQuantity;
            double targetQuantity = 1;

            if (quantity != null)
            {
                if (quan.Quantity > _ShelfStock)
                {
                    targetQuantity = _ShelfStock;
                }
                else if (_ShelfStock >= quan.Quantity)
                {
                    targetQuantity = quan.Quantity;
                }
            }
            else if (quantity == null)
            {
                if (_ShelfStock > 0)
                {
                    targetQuantity = 1;
                }
                if (_ShelfStock <= 0)
                {
                    targetQuantity = 0;
                }
            }

            // Calculations
            _ShelfStock -= targetQuantity;
            // ^^^^^

            if (targetQuantity == 0)
            {
                item = null;
                return false;
            }
            else
                item = new Item((Convert.ToInt32(targetQuantity)), (Line.Description), (targetQuantity * calculateweight));
            return true;

        }

        public override void AdjustStock(StockQuantity quantity)
        {
            if (quantity is PrePackedStockQuantity)
            {
                PrePackedStockQuantity quan = quantity as PrePackedStockQuantity;
                _StoredStock += quan.Quantity;
            }
        }

        public override void Restock()
        {
            _ShelfStock += (_StoredStock / calculateweight);
            _StoredStock = 0;
            return;
        }

        public override string ToString()
        {
            if (StoredStock != 0)
            {
                return string.Format("{0} packs ({1} g in storage)", _ShelfStock, _StoredStock);
            }
            else if (StoredStock == 1)
            {
                return string.Format("{0} pack ({1} g in storage)", _ShelfStock, _StoredStock);
            }
            else
            {
                return string.Format("{0} pack", _ShelfStock);
            }
        }
    }
}
