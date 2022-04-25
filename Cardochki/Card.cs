using System.Drawing;

namespace Cardochki
{
    class Card
    {
        public enum SUIT
        {
            DIAMOND, //буби
            HEARTS, //черви
            CLUBS,   //крести
            SPADES   //пики
        }
        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN,
            JACKET, LADY, KING, ACE  // 13 разных значений
        }

        public SUIT Suit { get; set; }
        public VALUE Value { get; set; }
        public Image Image { get; set; }
    }
}
