using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Retail_Database_Sys_AddPrePacked
{
    class Line
    {
        private string _ProductSKU;
        public string ProductSKU
        {
            get { return _ProductSKU; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
        }

        private Stock _Stock;
        public Stock Stock
        {
            get { return _Stock; }
        }

        private Line(string sku, string description)
        {
            _ProductSKU = sku;
            _Description = description;
        }

        private static List<Line> _SaleLines = new List<Line>();
        public static ReadOnlyCollection<Line> SaleLines
        {
            get { return _SaleLines.AsReadOnly(); }
        }

        public static Line SKU(string sku)
        {
            Line result = null;
            foreach (Line l in _SaleLines)
            {
                if (l.ProductSKU == sku)
                {
                    result = l;
                    break;
                }
            }
            return result;
        }

        public static bool CreateDiscreteLine(string sku, string description, double weightPerItem)
        {
            if (SKU(sku) != null)
                return false;

            Line line = new Line(sku, description);
            line._Stock = new DiscreteStock(line, weightPerItem);
            _SaleLines.Add(line);

            return true;
        }

        public static bool CreateWeighedLine(string sku, string description, double defaultSize)
        {
            if (SKU(sku) != null)
                return false;

            Line line = new Line(sku, description);
            line._Stock = new WeighedStock(line, defaultSize);
            _SaleLines.Add(line);

            return line != null;
        }
        public static bool CreatePrePackedLine(string sku, string description, double defaultWeight)
        {
            if (SKU(sku) != null)
                return false;

            Line line = new Line(sku, description);
            line._Stock = new PrePackedStock(line, defaultWeight);
            _SaleLines.Add(line);

            return line != null;
        }

        public bool Purchase(StockQuantity quantity, out Item items)
        {
            return _Stock.Purchase(quantity, out items);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1,-40} Stock: {2}", _ProductSKU, _Description, _Stock);
        }
    }
}