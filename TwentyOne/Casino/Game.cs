using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public abstract class Game
    {
        //make a private empty list and dictionary for use below
        private List<Player> _players = new List<Player>();
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();
        //get and set these with above private list and dict so they will never be null
        public List<Player> Players { get { return _players; } set { _players = value; } }
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } }

        public string Name { get; set; }

        //abstract method, any class inheriting Game class must define Play method
        public abstract void Play();
        

        //method to list all the players in the game
        //virtual method means that it can be overriden by inheriting classes
        public virtual void ListPlayers()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
