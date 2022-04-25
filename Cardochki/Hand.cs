using System.Windows.Forms;

namespace Cardochki
{
    class Hand
    {
        Card[] myHand;
        Card[] enemyHand;
        Card[] tableHand;

        Decka decka;

        public Hand(ImageList deck)
        {
            decka = new Decka();

            myHand = new Card[2];
            enemyHand = new Card[2];
            tableHand = new Card[5];
            decka.CreateDeck(deck);
        }

        public void GetHand(PictureBox myPB1, PictureBox myPB2, PictureBox enPB1, PictureBox enPB2)
        {
            for (int i = 0; i < 2; i++)
                myHand[i] = decka.getCards[i];
                
            for (int i = 2; i < 4; i++)
                enemyHand[i - 2] = decka.getCards[i];
            myPB1.Image = myHand[0].Image;
            myPB2.Image = myHand[1].Image;
            enPB1.Image = enemyHand[0].Image;
            enPB2.Image = enemyHand[1].Image;
        }
        public void GetTableHand(PictureBox cardPB1, PictureBox cardPB2, PictureBox cardPB3, PictureBox cardPB4, PictureBox cardPB5)
        {
            for (int i = 4; i < 9; i++)
                tableHand[i - 4] = decka.getCards[i];
            cardPB1.Image = tableHand[0].Image;
            cardPB2.Image = tableHand[1].Image;
            cardPB3.Image = tableHand[2].Image;
            cardPB4.Image = tableHand[3].Image;
            cardPB5.Image = tableHand[4].Image;
        }
        public void CheckHand(Label myLabel, Label enLabel)
        {
            Game myGame = new Game(myHand, tableHand);
            Game enemyGame = new Game(enemyHand, tableHand);
            Combination myComb = myGame.CardsInHand();
            Combination enemyComb = enemyGame.CardsInHand();
            myLabel.Text = myComb.ToString();
            enLabel.Text = enemyComb.ToString();
            if (myComb > enemyComb)
                MessageBox.Show("Победа");
            else if (myComb < enemyComb)
                MessageBox.Show("Поражение");
            else
                MessageBox.Show("Ничья");
        }
    }
}
