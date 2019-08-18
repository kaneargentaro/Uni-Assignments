using System;

namespace Black_Jack
{
    class Deck
    {
        public const int MAX_SUITS = 4;

        private Suit[] _Suits = new Suit[Deck.MAX_SUITS];
        private Random _Random = new Random((int)DateTime.Now.Ticks);

        public Deck()
        {
            _Suits[0] = new Suit(Card.CardSuit.Clubs);
            _Suits[1] = new Suit(Card.CardSuit.Diamonds);
            _Suits[2] = new Suit(Card.CardSuit.Hearts);
            _Suits[3] = new Suit(Card.CardSuit.Spades);
        }

        public Card Deal()
        {
            int which_suit = _Random.Next(1, Deck.MAX_SUITS);
            return _Suits[which_suit - 1].Deal();
        }
    }
}
