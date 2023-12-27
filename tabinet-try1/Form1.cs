using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tabinet_try1.Classes;

namespace tabinet_try1
{
    public partial class Tabla : Form
    {
        Deck deck = new Deck();
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");

        Board board = new Board();

        public void Initial()
        {
            deck.Shuffle();
            for (int i = 0; i < 6; i++)
            {
                Card cardP1 = deck.DrawCard();
                player1.AddCardToHand(cardP1);
                Card cardP2 = deck.DrawCard();
                player2.AddCardToHand(cardP2);
            }
            for(int i = 0; i < 4; i ++)
            {
                Card cardboard = deck.DrawCard();
                board.AddCardToBoard(cardboard);
            }
        }

        public string ImageString(Card card)
        {
            return card.Rank + "_of_" + card.Suit + ".png";
        }
        
        public void UpdateHandP1()
        {
            p1_card1.Image = Image.FromFile("../../Images/" + ImageString(player1.Hand[0]));
            p1_card2.Image = Image.FromFile("../../Images/" + ImageString(player1.Hand[1]));
            p1_card3.Image = Image.FromFile("../../Images/" + ImageString(player1.Hand[2]));
            p1_card4.Image = Image.FromFile("../../Images/" + ImageString(player1.Hand[3]));
            p1_card5.Image = Image.FromFile("../../Images/" + ImageString(player1.Hand[4]));
            p1_card6.Image = Image.FromFile("../../Images/" + ImageString(player1.Hand[5]));
        }
        public void UpdateHandP2()
        {
            p2_card1.Image = Image.FromFile("../../Images/" + ImageString(player2.Hand[0]));
            p2_card2.Image = Image.FromFile("../../Images/" + ImageString(player2.Hand[1]));
            p2_card3.Image = Image.FromFile("../../Images/" + ImageString(player2.Hand[2]));
            p2_card4.Image = Image.FromFile("../../Images/" + ImageString(player2.Hand[3]));
            p2_card5.Image = Image.FromFile("../../Images/" + ImageString(player2.Hand[4]));
            p2_card6.Image = Image.FromFile("../../Images/" + ImageString(player2.Hand[5]));
        }

        public void UpdateBoard()
        {
            tabla_card1.Image = Image.FromFile("../../Images/" + ImageString(board.Tabla[0]));
            tabla_card2.Image = Image.FromFile("../../Images/" + ImageString(board.Tabla[1]));
            tabla_card3.Image = Image.FromFile("../../Images/" + ImageString(board.Tabla[2]));
            tabla_card4.Image = Image.FromFile("../../Images/" + ImageString(board.Tabla[3]));
        }
        public Tabla()
        {
            InitializeComponent();
            
        }

        private void Tabla_Load(object sender, EventArgs e)
        {

        }

        private void p1_card1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Initial();
            UpdateHandP1();
            UpdateHandP2();
            UpdateBoard();
            btnStart.Hide();
            picturedeck.Show();
            

        }
        private int ct = 0;
        private void picturedeck_Click(object sender, EventArgs e)
        {

            if (ct % 3 == 0)
            {
                p1_card1.Show(); 
                p1_card2.Show();
                p1_card3.Show(); 
                p1_card4.Show(); 
                p1_card5.Show(); 
                p1_card6.Show();
                ct++;
            }

            else if (ct % 3 == 1)
            {
                p2_card1.Show();
                p2_card2.Show(); 
                p2_card3.Show(); 
                p2_card4.Show(); 
                p2_card5.Show(); 
                p2_card6.Show();
                ct++;
            }

            else if(ct % 3 == 2)
            {
                tabla_card1.Show();
                tabla_card2.Show();
                tabla_card3.Show();
                tabla_card4.Show();
                ct++;
            }
        }

        private void p1_card6_Click(object sender, EventArgs e)
        {

        }
    }
}
