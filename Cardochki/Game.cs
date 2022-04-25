using System.Collections.Generic;

namespace Cardochki
{
    public enum Combination
    {
        Nothing, //нет комбинаций
        OnePair, 
        TwoPairs,
        ThreeSame,
        Straight, //стрит (последовательность из пяти карт)
        Flush,   //флеш (пять карт одинаковой масти)
        FullHouse,  //фулл хаус (одна пара и тройка)
        FourPairs,  //каре (четыре карты одного номинала)
    }
    class Game
    {
        int diamondSum;
        int heartSum;
        int clubSum;
        int spadeSum;
        Card[] cards;
        Card[] tableCards;
        Card[] allCards;

        public Game(Card[] cardsHand, Card[] cardsTable)
        {
            diamondSum = 0;
            heartSum = 0;
            clubSum = 0;
            spadeSum = 0;
            cards = new Card[2];
            Cards = cardsHand;
            tableCards = new Card[5];
            TableCards = cardsTable;
            allCards = new Card[7];
            for (int i = 0; i < 2; i++)
            {
                allCards[i] = cards[i];
            }
            for (int i = 2; i < 7; i++)
            {
                allCards[i] = tableCards[i - 2];
            }

        }

        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
            }
        }
        public Card[] TableCards
        {
            get { return tableCards; }
            set
            {
                tableCards[0] = value[0];
                tableCards[1] = value[1];
                tableCards[2] = value[2];
                tableCards[3] = value[3];
                tableCards[4] = value[4];
            }
        }
        public Combination CardsInHand()
        {
            GetNumber();
            if (FourOfPairs())
                return Combination.FourPairs;
            else if (FullHouse())
                return Combination.FullHouse;
            else if (Flush())
                return Combination.Flush;
            else if (Straight())
                return Combination.Straight;
            else if (ThreeSame())
                return Combination.ThreeSame;
            else if (TwoPairs())
                return Combination.TwoPairs;
            else if (OnePair())
                return Combination.OnePair;
            return Combination.Nothing;
        }

        private void GetNumber()
        {
            foreach (var el in allCards)
            {
                if (el.Suit == Card.SUIT.DIAMOND)
                {
                    diamondSum++;
                }
                else if (el.Suit == Card.SUIT.HEARTS)
                {
                    heartSum++;
                }
                else if (el.Suit == Card.SUIT.CLUBS)
                {
                    clubSum++;
                }
                else if (el.Suit == Card.SUIT.SPADES)
                {
                    spadeSum++;
                }
            }
        }

        private bool FourOfPairs()
        {
            for (int i = 0; i < allCards.Length - 1; i++)
            {
                List<int> arrKare = new List<int>();
                for (int j = i + 1; j < allCards.Length; j++)
                {
                    if (allCards[i].Value == allCards[j].Value && arrKare.Count == 0)
                    {
                        arrKare.Add((int)allCards[i].Value);
                    }
                    else if (allCards[i].Value == allCards[j].Value && (int)allCards[j].Value == arrKare[0])
                    {
                        arrKare.Add((int)allCards[j].Value);
                    }
                }
                if (arrKare.Count == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public bool FullHouse()
        {
            //фул хаус работает только если в руке есть пара, а тройка - на столе (БОЛЬШЕ НИКАК)
            if (cards[0].Value == cards[1].Value && tableCards[0].Value == tableCards[1].Value && tableCards[0].Value == tableCards[2].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[0].Value == tableCards[1].Value && tableCards[0].Value == tableCards[3].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[0].Value == tableCards[1].Value && tableCards[0].Value == tableCards[4].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[0].Value == tableCards[2].Value && tableCards[0].Value == tableCards[3].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[0].Value == tableCards[2].Value && tableCards[0].Value == tableCards[4].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[0].Value == tableCards[3].Value && tableCards[0].Value == tableCards[4].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[1].Value == tableCards[2].Value && tableCards[1].Value == tableCards[3].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[1].Value == tableCards[2].Value && tableCards[1].Value == tableCards[4].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[1].Value == tableCards[3].Value && tableCards[1].Value == tableCards[4].Value)
            {
                return true;
            }
            else if (cards[0].Value == cards[1].Value && tableCards[2].Value == tableCards[3].Value && tableCards[2].Value == tableCards[4].Value)
            {
                return true;
            }
            return false;
        }
        private bool Flush()
        {
            if(heartSum == 5 || diamondSum == 5 || spadeSum == 5 || clubSum == 5)
            {
                return true;
            }
            return false;
        }

        private bool Straight()
        {
            for (int i = 0; i < allCards.Length - 1; i++)
            {
                int straightCount = 0;
                int plusOne = 1;
                for (int j = i + 1; j < allCards.Length; j++)
                {
                    if (allCards[i].Value + plusOne == allCards[j].Value)
                    {
                        straightCount++;
                        plusOne++;
                    }
                }
                if(straightCount == 5)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ThreeSame()
        {
            for (int i = 0; i < allCards.Length - 1; i++)
            {
                List<int> arrKare2 = new List<int>();
                for (int j = i + 1; j < allCards.Length; j++)
                {
                    if (allCards[i].Value == allCards[j].Value && arrKare2.Count == 0)
                    {
                        arrKare2.Add((int)allCards[i].Value);
                    }
                    else if (allCards[i].Value == allCards[j].Value && (int)allCards[j].Value == arrKare2[0])
                    {
                        arrKare2.Add((int)allCards[j].Value);
                    }
                }
                if (arrKare2.Count == 4)
                {
                    return true;
                }
            }
            return false;
        }

        private bool TwoPairs()
        {
            int countPairs = 0;
            int id1 = -1;
            int id2 = -1;
            for (int i = 0; i < allCards.Length - 1; i++)
            {
                for (int j = i + 1; j < allCards.Length; j++)
                {
                    if (allCards[i].Value == allCards[j].Value)
                    {
                        countPairs++;
                        if(countPairs == 1)
                        {
                            id1 = i;
                            id2 = j;
                            break;
                        }
                        if (countPairs == 2 && i != id1 && j != id2)
                        {
                            countPairs++;
                            return true;
                        }
                        else
                            countPairs--;   
                    }
                }     
            }
            return false;
        }

        private bool OnePair()
        {
            int id1 = -1;
            for (int i = 0; i < allCards.Length - 1; i++)
            {
                for (int j = i + 1; j < allCards.Length; j++)
                {
                    if (allCards[i].Value == allCards[j].Value)
                    {
                        id1 = i;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
