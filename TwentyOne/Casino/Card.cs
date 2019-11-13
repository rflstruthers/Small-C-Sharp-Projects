using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    //make card struct
    public struct Card
    {
        /////////Constructor doesnt work since creating enums for Suit and Face
        ////constructor (default values if none are assigned later)
        //public Card()
        //{
        //    Suit = "Spades";
        //    Face = "Two";
        //}

        //setting the properties of a card (suit andface value)
        //Suit is set to the enum Suit data type defined below
        //Face is set to the enum Face data type defined below
        public Suit Suit { get; set; }
        public Face Face { get; set; }

        //override the built in ToString method to give the card face and sui when called on
        public override string ToString()
        {
            return string.Format("{0} of {1}", Face, Suit);
        }

    }

    //making Suit an enum and defining the values
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    //making Face an enum and defining the values
    public enum Face
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

}
