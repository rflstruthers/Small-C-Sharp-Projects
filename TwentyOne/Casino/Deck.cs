using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck
    {
        //constructor: way of assigning values immediately upon creation
        public Deck()
        {
            // empty list for cards that are made to be added to
            Cards = new List<Card>();

            //nested for loop to make a deck of 52 cards
            //loop through all 13 Face values 4 times and assign a Suit
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;//converts int j to Face enum
                    card.Suit = (Suit)j;//converts int i to Suit enum
                    Cards.Add(card);
                }
            }


            ////////////////Below doesnt work anymore because in Card class
            ////////////////Suit was changed to an Enum
            ////Lists of card suits and faces
            //List<string> Suits = new List<string>() { "Clubs", "Hearts", "Diamonds", "Spades" };
            //List<string> Faces = new List<string>()
            //{
            //    "Two", "Three", "Four", "Five", "Six", "Seven",
            //    "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"
            //};

            ////nested for loop to make a deck of 52 cards
            ////goes through "Faces" list 4 times to make each card in a deck
            //foreach (string face in Faces)
            //{
            //    foreach (string suit in Suits)
            //    {
            //        //making a card, add it to list "Cards"
            //        Card card = new Card();
            //        card.Suit = suit;
            //        card.Face = face;
            //        Cards.Add(card);
            //    }
            //}


        }

        //class property
        public List<Card> Cards { get; set; }

        //method for shuffling
        //returns "Deck" data type
        //takes in "Deck" and "int" data types as parameters
        //sets int parameter to a default of 1
        //sets an out parameter to be an int saying how many times the deck was shuffled
        public void Shuffle(int times = 1)
        {
            
            //shuffle as many times as specified
            for (int i = 0; i < times; i++)
            {
                //temporary list of cards
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                //grab a random card, take it out of "Cards" list, add it to "TempList" list
                //do this till there are no cards in "Cards" list
                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);
                }
                Cards = TempList;
            }
        }

        ////another shuffle method for shuffling more than one time
        ////takes in data types "Deck" and "int" as parameters
        //public static Deck Shuffle(Deck deck, int times)
        //{
        //    for (int i = 0; i < times; i ++)
        //    {
        //        deck = Shuffle(deck);
        //    }
        //    return deck;
        //}
    }
}
