using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabinet_try1.Classes
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public int Valoare()
        {
            if (Rank == "ace") return 11;
            if (Rank == "2") return 2;
            if (Rank == "3") return 3;
            if (Rank == "4") return 4;
            if (Rank == "5") return 5;
            if (Rank == "6") return 6;
            if (Rank == "7") return 7;
            if (Rank == "8") return 8;
            if (Rank == "9") return 9;
            if (Rank == "10") return 10;
            if (Rank == "jack") return 12;
            if (Rank == "queen") return 13;
            if (Rank == "king") return 14;
            return 0;
        }
    }
}
