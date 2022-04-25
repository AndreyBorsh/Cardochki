using System;
using System.Windows.Forms;

namespace Cardochki
{
    public partial class Form1 : Form
    {
        Hand hand;
        public Form1()
        {
            InitializeComponent();
            cardPB1.Image = cardImages.Images[52];
            cardPB2.Image = cardImages.Images[52];
            cardPB3.Image = cardImages.Images[52];
            cardPB4.Image = cardImages.Images[52];
            cardPB5.Image = cardImages.Images[52];

            hand = new Hand(cardImages);
            hand.GetHand(myCardPB1, myCardPB2, enCardPB1, enCardPB2);
        }

        private void okletsgoBTN_Click(object sender, EventArgs e)
        {
            hand.GetTableHand(cardPB1, cardPB2, cardPB3, cardPB4, cardPB5);
            hand.CheckHand(myLabel, enemyLabel);
        }

        private void restartBTN_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
