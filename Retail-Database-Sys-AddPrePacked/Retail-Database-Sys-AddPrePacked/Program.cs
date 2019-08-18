using System;

namespace Retail_Database_Sys_AddPrePacked
{
    class Program
    {
        private static void PreloadData()
        {
            Line.CreateDiscreteLine("111111", "Original Corn Chips 150g", 0.15);
            Line.CreateDiscreteLine("222222", "Special Supreme Pizza 500g", 0.5);
            Line.CreateWeighedLine("333333", "Golden Delicious Apples", 0.175);
            Line.CreateWeighedLine("444444", "Button Mushrooms", 0.035);
            Line.CreatePrePackedLine("555555", "Australian Sausages 250g", 250);
            Line.CreatePrePackedLine("666666", "Lean Minced Meat 250g", 250);

            Line.SKU("111111").Stock.AdjustStock(new DiscreteStockQuantity(8));
            Line.SKU("111111").Stock.Restock();
            Line.SKU("111111").Stock.AdjustStock(new DiscreteStockQuantity(20));
            Line.SKU("222222").Stock.AdjustStock(new DiscreteStockQuantity(1));
            Line.SKU("222222").Stock.Restock();
            Line.SKU("222222").Stock.AdjustStock(new DiscreteStockQuantity(50));
            Line.SKU("333333").Stock.AdjustStock(new VolumeStockQuantity(2.0));
            Line.SKU("333333").Stock.Restock();
            Line.SKU("333333").Stock.AdjustStock(new VolumeStockQuantity(15.0));
            Line.SKU("444444").Stock.AdjustStock(new VolumeStockQuantity(1.0));
            Line.SKU("444444").Stock.Restock();
            Line.SKU("444444").Stock.AdjustStock(new VolumeStockQuantity(5.0));
            Line.SKU("555555").Stock.AdjustStock(new PrePackedStockQuantity(1000.000));
            Line.SKU("555555").Stock.Restock();
            Line.SKU("555555").Stock.AdjustStock(new PrePackedStockQuantity(5000.000));
            Line.SKU("666666").Stock.AdjustStock(new PrePackedStockQuantity(1500.000));
            Line.SKU("666666").Stock.Restock();
            Line.SKU("666666").Stock.AdjustStock(new PrePackedStockQuantity(2000.000));


        }

        static void Main(string[] args)
        {
            PreloadData();

            Console.WriteLine("=====================");
            Console.WriteLine("Stock Before Purchase");
            Console.WriteLine("=====================");
            foreach (Line line in Line.SaleLines)
                Console.WriteLine("- {0}", line);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Receipt rcpt = new Receipt();
            Item purchasedItem;
            if (Line.SKU("111111").Purchase(new DiscreteStockQuantity(5), out purchasedItem) == true)
                rcpt.Add(purchasedItem);
            if (Line.SKU("222222").Purchase(null, out purchasedItem) == true)
                rcpt.Add(purchasedItem);
            if (Line.SKU("222222").Purchase(null, out purchasedItem) == true)
                rcpt.Add(purchasedItem);
            if (Line.SKU("333333").Purchase(new VolumeStockQuantity(0.555), out purchasedItem) == true)
                rcpt.Add(purchasedItem);
            if (Line.SKU("444444").Purchase(null, out purchasedItem) == true)
                rcpt.Add(purchasedItem);
            if (Line.SKU("444444").Purchase(new VolumeStockQuantity(3.000), out purchasedItem) == true)
                rcpt.Add(purchasedItem);
            if (Line.SKU("555555").Purchase(new PrePackedStockQuantity(2.000), out purchasedItem) == true)
                rcpt.Add(purchasedItem);
            if (Line.SKU("555555").Purchase(null, out purchasedItem) == true)
                rcpt.Add(purchasedItem);
            if (Line.SKU("666666").Purchase(new PrePackedStockQuantity(10.000), out purchasedItem) == true)
                rcpt.Add(purchasedItem);


            Console.WriteLine("=======");
            Console.WriteLine("Receipt");
            Console.WriteLine("=======");
            Console.WriteLine(rcpt.GetText());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("====================");
            Console.WriteLine("Stock After Purchase");
            Console.WriteLine("====================");
            foreach (Line line in Line.SaleLines)
                Console.WriteLine("- {0}", line);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Line.SKU("111111").Stock.Restock();
            Line.SKU("222222").Stock.Restock();
            Line.SKU("333333").Stock.Restock();
            Line.SKU("444444").Stock.Restock();
            Line.SKU("555555").Stock.Restock();
            Line.SKU("666666").Stock.Restock();
            Console.WriteLine("=================");
            Console.WriteLine("Restock All Items");
            Console.WriteLine("=================");
            foreach (Line line in Line.SaleLines)
                Console.WriteLine("- {0}", line);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
