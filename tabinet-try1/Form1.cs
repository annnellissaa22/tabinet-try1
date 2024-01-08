using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tabinet_try1.Classes;

namespace tabinet_try1
{
    public partial class Tabla : Form
    {
        Deck deck = new Deck();
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");
        Player currentPlayer;
        List<PictureBox> TableCardsVisual = new List<PictureBox>();
        List<PictureBox> P1CardsVisual = new List<PictureBox>();
        List<PictureBox> P2CardsVisual = new List<PictureBox>();
        int selectedCard;
        int sum = 0;

        Board board = new Board();

        public void Initial()
        {
            deck.Shuffle();
            currentPlayer = player1;
            for (int i = 0; i < 6; i++)
            {
                Card cardP1 = deck.DrawCard();
                player1.AddCardToHand(cardP1);
                Card cardP2 = deck.DrawCard();
                player2.AddCardToHand(cardP2);
            }
            for (int i = 0; i < 4; i++)
            {
                Card cardboard = deck.DrawCard();
                board.AddCardToBoard(cardboard);
            }
        }

        public string ImageString(Card card)
        {
            return card.Rank + "_of_" + card.Suit + ".png";
        }

        private void UpdateInterface()
        {
            UpdateHandP1();
            UpdateHandP2();
            UpdateBoard();
        }

        public void UpdateHandP1()
        {
            foreach (PictureBox pic in P1CardsVisual)
                pic.Image = null;
            for (int i = 0; i < P1CardsVisual.Count; i++)
            {
                P1CardsVisual[i].Image = Image.FromFile("../../Images/" + ImageString(player1.Hand[i]));
            }

        }
        public void UpdateHandP2()
        {
            foreach (PictureBox pic in P2CardsVisual)
                pic.Image = null;
            for (int i = 0; i < P2CardsVisual.Count; i++)
            {
                P2CardsVisual[i].Image = Image.FromFile("../../Images/" + ImageString(player2.Hand[i]));
            }
        }

        public void UpdateBoard()
        {
            foreach (PictureBox pic in TableCardsVisual)
            {
                pic.Image = null;
            }
            for (int i = 0; i < board.Tabla.Count; i++)
            {
                TableCardsVisual[i].Image = Image.FromFile("../../Images/" + ImageString(board.Tabla[i]));
            }

        }
        public Tabla()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TableCardsVisual.Add(tabla_card1);
            TableCardsVisual.Add(tabla_card2);
            TableCardsVisual.Add(tabla_card3);
            TableCardsVisual.Add(tabla_card4);

            P1CardsVisual.Add(p1_card1);
            P1CardsVisual.Add(p1_card2);
            P1CardsVisual.Add(p1_card3);
            P1CardsVisual.Add(p1_card4);
            P1CardsVisual.Add(p1_card5);
            P1CardsVisual.Add(p1_card6);

            P2CardsVisual.Add(p2_card1);
            P2CardsVisual.Add(p2_card2);
            P2CardsVisual.Add(p2_card3);
            P2CardsVisual.Add(p2_card4);
            P2CardsVisual.Add(p2_card5);
            P2CardsVisual.Add(p2_card6);

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
                foreach (PictureBox picture in P1CardsVisual)
                {
                    picture.Show();
                }
                ct++;
            }

            else if (ct % 3 == 1)
            {
                foreach (PictureBox picture in P2CardsVisual)
                {
                    picture.Show();
                }
                ct++;
            }

            else if (ct % 3 == 2)
            {
                foreach (PictureBox picture in TableCardsVisual)
                {
                    picture.Show();
                }
                ct++;
            }
        }
        public void VerifCardEqual(Card cardboard)
        {

            if (currentPlayer.Hand[selectedCard].Valoare() == cardboard.Valoare())
            {
                if (currentPlayer.Hand[selectedCard].Valoare() >= 11)
                    currentPlayer.Points++;

                P1Points.Text = player1.Points.ToString(); //de sters
                currentPlayer.Hand.RemoveAt(selectedCard);
                board.Tabla.Remove(cardboard);
                UpdateInterface();

            }
        }

        public void VerifCardSum(Board board)
        {

            for (int i = 0; i < board.Tabla.Count; i++)
            {
                while (sum <= currentPlayer.Hand[selectedCard].Valoare())
                {
                    sum += board.Tabla[i].Valoare();
                    if (board.Tabla[i].Valoare() > 11) currentPlayer.Points++;
                    board.Tabla.RemoveAt(i);
                }
            }
            currentPlayer.Hand.RemoveAt(selectedCard);
            if(currentPlayer == player1)
            {
                P1CardsVisual[selectedCard].Image = null;
                P1CardsVisual.RemoveAt(selectedCard);
                currentPlayer = player2;
            }
            else
            {
                P2CardsVisual[selectedCard].Image = null;
                P2CardsVisual.RemoveAt(selectedCard);
                currentPlayer = player1;
            }



        }


        private void p1_card6_Click(object sender, EventArgs e)
        {

        }

        private void TableCardSelected(object sender, EventArgs e)
        {
            for (int i = 0; i < TableCardsVisual.Count; i++)
            {
                if (TableCardsVisual[i] == sender as PictureBox)
                {
                    VerifCardEqual(board.Tabla[i]);
                }
                for (int j = 0; j < TableCardsVisual.Count; j++)
                {
                    if (TableCardsVisual[j] == sender as PictureBox)
                    {
                        VerifCardSum(board);
                    }
                }
            }
        }

        private void PlayerCardSelect(object sender, EventArgs e)
        {
            for (int i = 0; i < P1CardsVisual.Count; i++)
            {
                if (currentPlayer == player1)
                {
                    if (P1CardsVisual[i] == sender as PictureBox)
                    {
                        selectedCard = i;
                        return;
                    }

                }
                else if (currentPlayer == player2)
                {
                    if (P2CardsVisual[i] == sender as PictureBox)
                    {
                        selectedCard = i;
                        return;
                    }
                }
            }
        }

        private void p2_card3_Click(object sender, EventArgs e)
        {

        }
    }
}
