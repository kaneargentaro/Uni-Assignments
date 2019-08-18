using System;

namespace Black_Jack
{
    class Suit
    {
        public const ushort MAX_CARDS = 13;

        private Card[] _UndealtCards = new Card[Suit.MAX_CARDS];
        private Card.CardSuit _Suit;
        private Random _Random = new Random();

        public Suit(Card.CardSuit WhichSuit)
        {
            _Suit = WhichSuit;
            for (int i = 0; i < Suit.MAX_CARDS; i++)
                _UndealtCards[i] = new Card(_Suit, i + 1);
        }

        public Card Deal()
        {
                int id = _Random.Next(0, Suit.MAX_CARDS);

                Card c = _UndealtCards[id];
                _UndealtCards[id] = null;

                if (c == null)

                    throw new Exception("Card already dealt");

                return c;

        }
    }
}
