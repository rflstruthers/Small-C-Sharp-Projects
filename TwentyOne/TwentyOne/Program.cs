using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Casino;
using Casino.TwentyOne;
using System.Data.SqlClient;
using System.Data;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting the game, setting user input to variables
            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();
            //if the player enters "admin" as their name, print the exceptions that were logged 
            //into the database
            if (playerName.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions();
                foreach (var exception in Exceptions)
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptionType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + " | ");
                    Console.WriteLine();
                }
                Console.Read();
                return;
            }
            //check if users answer is correct format
            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank);
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals.");
            }

            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "yup" || answer == "ok" || answer == "okay" || answer == "y")
            {
                //instantiated Player class with values for constructor variables
                Player player = new Player(playerName, bank);
                //assigning Guid to player
                player.Id = Guid.NewGuid();
                using (StreamWriter file = new StreamWriter(@"C:\Users\User0\Logs\TwentyOneGameLog.txt", true))
                {
                    file.WriteLine("User ID = {0}", player.Id);
                }
                    //instantiated Game class as a new TwentyOneGame using polymorphism
                    Game game = new TwentyOneGame();
                //adding the user to the game as a player using overloaded operator
                game += player;
                player.isActivelyPlaying = true;
                //keep the game going while player wants to play and has money
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    //play method, abstract from Game class, overridden in TwentyOneGame class
                    //wrapped in a try/catch to catch any exceptions that may occur
                    try
                    {
                        game.Play();
                    }
                    catch (FraudException ex)
                    {
                        Console.WriteLine(ex.Message);
                        UpdateDbWithExceptions(ex);
                        Console.ReadLine();
                        return;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Something you entered was incorrect.");
                        UpdateDbWithExceptions(ex);
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured. Please contact your System Administrator.");
                        UpdateDbWithExceptions(ex);
                        Console.ReadLine();
                        return;
                    }
                    
                }
                //player is done playing
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            //if user doesn't want to play
            Console.WriteLine("Feel free to look around the casino. Bye for now.");

            Console.ReadLine();





            ////Object of data type Deck assigned to variable "deck"
            //Deck deck = new Deck();

            ////calling "Shuffle" method from "Deck" class
            //deck.Shuffle(3);


            ////counting all elements "x" in "deck" with the Face value of Ace
            ////using lambda expression
            //int count = deck.Cards.Count(x => x.Face == Face.Ace);
            //Console.WriteLine(count);

            ////Lambda function to get all kings from the deck and put them in 
            ////the list "newList" and print each value in "newList"
            //List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();
            //foreach ( Card card in newList)
            //{
            //    Console.WriteLine(card.Face);
            //}
            

            ////instantiating TwentyOneGame, Player list, and Player
            ////adding a name to Player, adding a Player to the game using overloaded operator
            //Game game = new TwentyOneGame();
            //game.Players = new List<Player>();
            //Player player = new Player();
            //player.Name = "Jesse";
            //game = game + player;
            ////game = game - player;


            ////instantiating TwentyOneGame, adding names to Players, calling ListPlayers()
            //TwentyOneGame game = new TwentyOneGame();
            //game.Players = new List<string>() { "Jesse", "Bill", "Joe" };
            //game.ListPlayers();


            ////polymorphism: one class can change into another class
            //Game game = new TwentyOneGame();


            ////Instantiate TwentyOneGame class, it inherits characteristics 
            ////from Game class so we can use "Players" and "Dealer" and "ListPlayers()"
            //TwentyOneGame game = new TwentyOneGame();
            //game.Players = new List<string>() { "Jesse", "Bill", "Joe" };
            //game.ListPlayers();


            ////Instantiating card object with face and suit values
            //Card card = new Card() { Face = "King", Suit = "Spades" };


            ////calling second Shuffle method
            //deck = Shuffle(deck, 3);


            ////print all cards in deck
            //foreach (Card card in deck.Cards)
            //{
            //    Console.WriteLine(card.Face + " of " + card.Suit);
            //}


            ////print number of cards in deck
            //Console.WriteLine(deck.Cards.Count);


            //Console.ReadLine();
        }


        //method to log exceptions to database
        private static void UpdateDbWithExceptions(Exception ex)
        {
            //connection string from db properties 
            string connectionString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = 
                                TwentyOneGame; Integrated Security = True; Connect Timeout = 30; 
                                Encrypt = False; TrustServerCertificate = False; ApplicationIntent = 
                                ReadWrite; MultiSubnetFailover = False";

            //SQL statement to add data to table, the @ColumnName where the values should be is used to protect 
            //against db injection, it makes sure the user doesnt mess up the db
            string queryString = @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) 
                                 VALUES (@ExceptionType, @ExceptionMessage, @TimeStamp)";

            //using statement closes connection to SQL when done so it doesnt use up too much memory
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //adding parameters' data type to be entered in each column
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                //adding parameters' values to be entered in each column
                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                //open connection to database, add data to database, close the connection
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        //method to get data logged in database
        private static List<ExceptionEntity> ReadExceptions()
        {
            //connection string from db properties 
            string connectionString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = 
                                TwentyOneGame; Integrated Security = True; Connect Timeout = 30; 
                                Encrypt = False; TrustServerCertificate = False; ApplicationIntent = 
                                ReadWrite; MultiSubnetFailover = False";

            //SQL query for desired data
            string querySring = @"SELECT Id, ExceptionType, ExceptionMessage, TimeStamp FROM Exceptions";

            //creating empty list
            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();

            //connect to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(querySring, connection);
                connection.Open();

                //read data from database based on queryString
                SqlDataReader reader = command.ExecuteReader();

                //adding data from the database to the ExceptionEntity class
                while (reader.Read())
                {
                    ExceptionEntity exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]);
                    exception.ExceptionType = reader["ExceptionType"].ToString();
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);

                    Exceptions.Add(exception);
                }
                connection.Close();
            }
            return Exceptions;
        }
    }
}
