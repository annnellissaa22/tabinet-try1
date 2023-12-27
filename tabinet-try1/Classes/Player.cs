﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabinet_try1.Classes
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public Card SelectCard(int index)
        {
            if (index >= 0 && index < Hand.Count)
            {
                Card selectedCard = Hand[index];
                return selectedCard;
            }
            else
            {
                return null; 
            }
        }
    }
}
