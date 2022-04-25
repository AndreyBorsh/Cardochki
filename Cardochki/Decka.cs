using System;
using System.Windows.Forms;

namespace Cardochki
{
    class Decka : Card
    {
        readonly int countOfCards = 52;
        Card[] deck;

        public Decka()
        {
            deck = new Card[countOfCards];
            ShuffleCards();
        }
        public Card[] getCards { get { return deck; } }

        public void CreateDeck(ImageList deckOfCards)
        {
            int i = 0;
            foreach (SUIT suit in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE value in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { Suit = suit, Value = value, Image = deckOfCards.Images[i] };
                    i++;
                }
            }
            ShuffleCards();
        }

        public void ShuffleCards()
        {
            Random rnd = new Random();
            Card countTime;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < countOfCards; j++)
                {
                    int nextCard = rnd.Next(52);
                    countTime = deck[i];
                    deck[i] = deck[nextCard];
                    deck[nextCard] = countTime;
                }
            }
        }
    }
}
