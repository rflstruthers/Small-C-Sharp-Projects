using System;
using System.Text;

namespace StringExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please answer a few questions about yourself.\n\nWhat is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("What color is your house?");
            string color = Console.ReadLine();
            Console.WriteLine("What state do you live in?");
            string state = Console.ReadLine();
            Console.WriteLine("Hi " + name + ", based on our records you live in a " + color + " house in " + state.ToUpper() + ".");

            StringBuilder sb = new StringBuilder();
            sb.Append("We believe that you could be in the market for a new home! ");
            sb.Append("There are several great deals in your area right now.\n");
            sb.Append("An agent will be contacting you soon about theses and many other exciting offers!");
            Console.WriteLine(sb);
            Console.ReadLine();
        }
    }
}
