using System;
using System.Collections.Generic;

namespace Retail_Database_Sys_AddPrePacked
{
    class WeighedStock : Stock
    {
        private double _StoredStock;
        private double _ShelfStock;
        private double _DefaultPurchase;

        public double StoredStock
        {
            get { return _StoredStock; }
        }
        public double ShelfStock
        {
            get { return _ShelfStock; }
        }
        public double DefaultPurchase
        {
            get { return _DefaultPurchase; }
        }

        public WeighedStock(Line line, double defaultpurchase) : base(line)
        {
            _DefaultPurchase = defaultpurchase;
            _ShelfStock = 0;
            _StoredStock = 0;
        }

        public override bool Purchase(StockQuantity quantity, out Item item)
        {
            VolumeStockQuantity quan = quantity as VolumeStockQuantity;
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
                    targetQuantity = _DefaultPurchase;
                }
                else if (_ShelfStock - _DefaultPurchase <= 0)
                {
                    targetQuantity = 0;
                }
                else if (_ShelfStock - quan.Quantity <= 0)
                {
                        targetQuantity = 0;
                }
            }

            // Calculations
            _ShelfStock -= targetQuantity;

            if (targetQuantity == 0)
            {
                item = null;
                return false;
            }
            else
                item = new Item((1), (Line.Description + " " + targetQuantity + " kg"), (targetQuantity));
            return true;

            /// old code - using for reference in the future - please ignore
            /* bool QuantityIsVolume = false;
            VolumeStockQuantity quan = quantity as VolumeStockQuantity;
            if (quantity is VolumeStockQuantity)
                {
                    QuantityIsVolume = true;
                }
            else if (quantity is DiscreteStockQuantity || quantity == null)
            {
                    QuantityIsVolume = false;
                }
            
                if (QuantityIsVolume == true)
                {
                        if (quan.Quantity > _ShelfStock)
                        {
                            double maxshelf = _ShelfStock;
                            _ShelfStock -= maxshelf;
                        }
                        else if (_ShelfStock >= quan.Quantity)
                        {
                            _ShelfStock -= quan.Quantity;
                        }
                 }
            else if (QuantityIsVolume == false)
            {
                        if (_ShelfStock > _DefaultPurchase)
                        {
                            _ShelfStock -= _DefaultPurchase;
                        }
               }
   
                if (quantity == null)
                {
            
                    item = null;
                    return false;
                }
                else
                    item = new Item((1), (Line.Description + " " + quan.Quantity + " kg"), (quan.Quantity));
                    return true; */



        }

        public override void AdjustStock(StockQuantity quantity)
        {
            if (quantity is VolumeStockQuantity)
            {
                VolumeStockQuantity quan = quantity as VolumeStockQuantity;
                _StoredStock += quan.Quantity;
                return;
            }
        }

        public override void Restock()
        {
            _ShelfStock += _StoredStock;
            _StoredStock = 0;
            return;
        }

        public override string ToString()
        {
            if (StoredStock != 0)
            {
                return string.Format("{0:0.000} kg ({1:0.000} kg in storage)", ShelfStock, StoredStock);
            }
            else
            {
                return string.Format("{0:0.000} kg", ShelfStock);
            }
        }
    }
}
