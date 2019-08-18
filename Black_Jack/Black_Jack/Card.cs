using System;

namespace Black_Jack
{
    class Card
    {
        public enum CardSuit
        {
            Clubs,
            Spades,
            Hearts,
            Diamonds
        }

        public static readonly string[] CARD_NAMES = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        private CardSuit _Suit;
        private int _Number;

        public Card(CardSuit Suit, int Number)
        {
            _Suit = Suit;
            _Number = Number;
        }

        public int GetBJValue()
        {
            return (_Number > 10 ? 10 : _Number);
        }

        public override string ToString()
        {
            return string.Format("Card is the {0} of {1}", Card.CARD_NAMES[_Number - 1], _Suit.ToString());
        }
    }
}
