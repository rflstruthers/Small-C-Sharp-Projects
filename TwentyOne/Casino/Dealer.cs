using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        //Deal() takes in a list of cards called "Hand"
        //adds first card from deck to hand and prints it
        //remove that card from deck
        //logs what cards were dealt
        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First());
            string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(card);
            //when using statement is done, memory is cleaned up
            //StreamWriter writes text to desired file location
            using (StreamWriter file = new StreamWriter(@"C:\Users\User0\Logs\TwentyOneGameLog.txt", true))
            {
                file.WriteLine(DateTime.Now);//adds timestamp to log
                file.WriteLine(card);
            }
            Deck.Cards.RemoveAt(0);
        }
    }
}
