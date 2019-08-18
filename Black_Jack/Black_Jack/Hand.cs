using System;

namespace Black_Jack
{
    class Hand
    {
        public const int MAX_CARDS_IN_HAND = 10; // arbitrary
        public const int MAX_HAND_VALUE = 21;

        private Card[] _Cards = new Card[Hand.MAX_CARDS_IN_HAND];

        private void Validate()
        {
            if (GetValue() > Hand.MAX_HAND_VALUE)
                throw new Exception("Busted!");
        }

        public void AddCard(Card TheCard)
        {
            int i;
            for (i = 0; i < Hand.MAX_CARDS_IN_HAND; i++)
            {
                if (_Cards[i] == null)
                    break;
            }
            _Cards[i] = TheCard;
            Validate();
        }

        public void Print()
        {
            foreach (Card c in _Cards)
            {
                if (c == null)
                    continue;
                Console.WriteLine(c);
            }
        }

        public int GetValue()
        {
            int value = 0;

            foreach (Card c in _Cards)
            {
                if (c == null)
                    continue;
                value += c.GetBJValue();
            }

            return value;
        }
    }
}
