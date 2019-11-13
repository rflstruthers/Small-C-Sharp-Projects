using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Interfaces;

namespace Casino.TwentyOne
{
    //TwentyOneGame class inherits characteristics and methods from
    //Game class
    public class TwentyOneGame : Game, IWalkAway
    {
        //dealer property specific to 21
        public TwentyOneDealer Dealer { get; set; }

        //must have override keyword because it is an abstract method from Game class
        public override void Play()
        {
            //starting gameplay, create a Dealer and empty Dealer Hand list, create empty player Hand list and make sure Stay is false for both
            Dealer = new TwentyOneDealer();
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false;
            }
            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            //instantiate Deck
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle();
            
            foreach (Player player in Players)
            {
                //make sure user enters digits only for bet
                bool validAnswer = false;
                int bet = 0;
                while (!validAnswer)
                {
                    Console.WriteLine("Place your bet!");
                    validAnswer = int.TryParse(Console.ReadLine(), out bet);
                    if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals.");
                }
                //give error message if bet is negative
                if (bet < 0)
                {
                    throw new FraudException("Security! Kick this person out!");
                }
                //call Bet method and pass in players bet, get boolean return.
                //If the bet fails, go back to "Place your bet!"
                bool successfullyBet = player.Bet(bet);
                if (!successfullyBet)
                {
                    return;//end this method
                }
                //adds player and their bet to Bets dictionary from the Game class
                Bets[player] = bet;
            }
            //Deal the player cards
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand);
                    if (i == 1)
                    {
                        //check for blackjack
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand);
                        if (blackJack)
                        {
                            //give wining player their bet plus their bet times 1.5
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]);
                            return;
                        }
                    }
                }
                //deal the dealer cards and se if they have blackjack
                Console.Write("Dealer: ");
                Dealer.Deal(Dealer.Hand);
                if (i == 1)
                {
                    bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);
                    if (blackJack)
                    {
                        //dealer wins and gets all the players bets
                        Console.WriteLine("Dealer has Blackjack! Everyone looses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        {
                            Dealer.Balance += entry.Value;
                        }
                        return;
                    }
                }
            }
            //go through each player, show their cards and ask if they want to hit or saty
            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.WriteLine("Your cards are: ");
                    foreach (Card card in player.Hand)
                    {
                        Console.Write("{0} ", card.ToString());//overriden ToString method used to show cards
                    }
                    Console.WriteLine("\n\nHit or stay?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;//while loop stops if player stays
                    }
                    else if (answer == "hit")
                    {
                        Dealer.Deal(player.Hand);//gives player another card
                    }
                    //call IsBusted method to from TwentyOneRules class
                    //if they bust, give their bet to the dealer and ask if they want to play again
                    bool busted = TwentyOneRules.IsBisted(player.Hand);
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];
                        Console.WriteLine("{0} Busted! You loose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Balance);
                        Console.WriteLine("Do you want to play again?");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "yup" || answer == "ok" || answer == "okay" || answer == "y")
                        {
                            player.isActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                            return;
                        }
                    }
                }
            }
            //check is dealer is bust and if they should stay
            Dealer.isBusted = TwentyOneRules.IsBisted(Dealer.Hand);
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            //deal dealer cards till they're bust or have to stay
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = TwentyOneRules.IsBisted(Dealer.Hand);
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staying.");
            }
            //if dealer busts, give players their bets back
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won {1}!", entry.Key.Name, entry.Value);
                    //Where() gets the players name and puts them on a list, First() takes the first item on that list (the player)
                    //and then we add their bet times 2 to their bank balance
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);
                    //take money away from dealer
                    Dealer.Balance -= entry.Value;
                }
                return;
            }
            //compare each players hand to the dealers hand, determine who won and give appropriate money to the winner
            foreach (Player player in Players)
            {
                //the "?" turns the boolean data type able to be null
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);
                if (playerWon == null)
                {
                    Console.WriteLine("Push! No one wins.");
                    player.Balance += Bets[player];
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += (Bets[player] * 2);
                    Dealer.Balance -= Bets[player];
                }
                else
                {
                    Console.WriteLine("Dealer wins {0}!", Bets[player]);
                    Dealer.Balance += Bets[player];
                }

                //ask if players want to play again
                Console.WriteLine("Play again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "yup" || answer == "ok" || answer == "okay" || answer == "y")
                {
                    player.isActivelyPlaying = true;
                }
                else player.isActivelyPlaying = false;
            }
            
        }

        //inherits method from Game, can override it because it is a virtual method
        public override void ListPlayers()
        {
            Console.WriteLine("21 Players: ");
            base.ListPlayers();
        }

        //inherits from IWalkAway interface, must implement the method
        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
