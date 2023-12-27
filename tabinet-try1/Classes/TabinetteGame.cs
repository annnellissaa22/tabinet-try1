using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace tabinet_try1.Classes
{
    public class TabinetteGame
    {
        private Deck deck;
        private List<Player> players;
        private Board board; 

        public TabinetteGame()
        {
            deck = new Deck();
            deck.Shuffle();

            players = new List<Player>();
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            Board board = new Board(); 

            players.Add(player1);
            players.Add(player2);
        }
        public void DealInitialCards(List<Player> players, int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                foreach (Player player in players)
                {

                    Card drawCard = deck.DrawCard(); // Scoatem o carte din pachet
                    if (drawCard != null)
                    {
                        player.AddCardToHand(drawCard); // Adaugam cartea in mana playerului
                    }
                    else
                    {
                        Console.WriteLine("Nu mai sunt carti in pachet.");
                        break; // Se opreste daca nu mai exista carti in pachet.
                    }
                }
            }
        }
            public bool IsGameOver()
            {
                return deck.CardsCount() == 0; 
            }


        public void PlayRound()
        {
           

           
        }
    }
}
