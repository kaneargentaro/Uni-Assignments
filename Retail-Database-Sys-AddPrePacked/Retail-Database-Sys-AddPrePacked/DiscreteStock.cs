using System;
using System.Collections.Generic;

namespace Retail_Database_Sys_AddPrePacked
{
    class DiscreteStock : Stock
    {
        private int _StoredStock;
        private int _ShelfStock;
        private double _WeightPerItem;

        public double StoredStock
        {
            get { return _StoredStock; }
        }
        public double ShelfStock
        {
            get { return _ShelfStock; }
        }
        public double WeightPerItem
        {
            get { return _WeightPerItem; }
        }

        public DiscreteStock(Line line, double weightperitem) : base(line)
        {

            _WeightPerItem = weightperitem;
            _ShelfStock = 0;
            _StoredStock = 0;
        }

        public override bool Purchase(StockQuantity quantity, out Item item)
        {
            DiscreteStockQuantity quan = quantity as DiscreteStockQuantity;
            int targetQuantity = 1;

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
                item = new Item((targetQuantity), Line.Description, (targetQuantity * WeightPerItem));
            return true;

            // OLD CODE THAT DIDN'T WORK - KEEPING IT FOR REFERENCE //
           /* if (quantity is DiscreteStockQuantity)
                {
                    QuantityIsDiscrete = true;
                }
                else if (quantity is VolumeStockQuantity || quantity == null)
                { 
                    QuantityIsDiscrete = false;
                }


                if (QuantityIsDiscrete == true)
                {
                     if (quan.Quantity > _ShelfStock)
                     {
                        int maxshelf = quan.Quantity;
                        _ShelfStock -= maxshelf;
                     }
                     else if (_ShelfStock >= quan.Quantity)
                     {
                        _ShelfStock -= quan.Quantity;
                     }
                 }
                else if (QuantityIsDiscrete == false)
                {
                        if (_ShelfStock > 0)
                        {
                            _ShelfStock -= 1;
                        }
                       
            }
            if(quantity == null)
            {
                item = null;
                return false;
            }
            else         
            item = new Item((quan.Quantity), Line.Description, (quan.Quantity * WeightPerItem));
            return true; */



        }

        public override void AdjustStock(StockQuantity quantity)
        {
            if (quantity is DiscreteStockQuantity)
                {
                DiscreteStockQuantity quan = quantity as DiscreteStockQuantity;
                _StoredStock += quan.Quantity;
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
                return string.Format("{0} ({1} in storage)", _ShelfStock, _StoredStock);
            }
            else
            {
                return string.Format("{0}", _ShelfStock);
            }
        }
    }
}
