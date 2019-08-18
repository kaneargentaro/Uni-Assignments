using System;

namespace Black_Jack
{
    class Program
    {
        public static void Main()
        {
            Dealer dealer = new Dealer();
            Hand theHand;

            try
            {
                theHand = dealer.Deal();
                while (true)
                {
                    Console.WriteLine("The hand is as follows:");
                    theHand.Print();
                    Console.WriteLine("The hand is worth {0}", theHand.GetValue());
                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to deal another card...");
                    Console.ReadLine();
                    dealer.Hit();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("An exception occurred: {0}", e.Message);
            }
        }
    }
}
