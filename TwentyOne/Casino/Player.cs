using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player
    {
        //constructor callchain, if no initial balance is set, default to 100
        public Player( string name) : this(name, 100)
        { }
        //Constructor
        public Player(string name, int beginningBalance)
        {
            Hand = new List<Card>();
            Balance = beginningBalance;
            Name = name;
        }

        //make private list so that the public list is never null
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }

        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        //GUID for player
        public Guid Id { get; set; }
        public bool Stay { get; set; }

        //Bet method taking in amount parameter and returning a boolean
        //if bet is bigger than players bank, reject the bet, if not acept it and subtract the bet amount from their bank
        public bool Bet(int amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("You do not have enough to place a bet that size.");
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }

        //overloading operator "+", putting in two operands "game" and "player"
        //returning Game
        //takes game, adds player to it and returns game
        public static Game operator+ (Game game, Player player)
        {
            game.Players.Add(player);
            return game;
        }

        //overloading "-" operator
        //takes game, removes a player, and returns game
        public static Game operator- (Game game, Player player)
        {
            game.Players.Remove(player);
            return game;
        }

    }
}
