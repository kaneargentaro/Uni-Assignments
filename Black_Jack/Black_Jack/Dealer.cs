using System;

namespace Black_Jack
{
    class Dealer
    {
        private Deck _PlayingDeck = new Deck();
        private Hand _CurrentHand;

        public Hand Deal()
        {
            _CurrentHand = new Hand();
            Console.WriteLine("Dealer deals a new hand");
            Hit();
            Hit();
            return _CurrentHand;
        }

        public void Hit()
        {
            Card dealtCard;

            if (_CurrentHand == null)
                throw new Exception("No hand");

            dealtCard = _PlayingDeck.Deal();
            Console.WriteLine("Dealer deals the {0}", dealtCard);
            _CurrentHand.AddCard(dealtCard);
        }
    }
}
