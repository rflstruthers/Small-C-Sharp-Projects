using System;
using System.Collections.Generic;

namespace IterationExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates an array, asks for user input, iterates through the list and concatenates user input with items in list. 
            string[] likes = { "likes dogs", "likes pizza", "likes nature", "likes beer", "likes numbers" };
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            for (int i = 0; i < likes.Length; i++)
            {
                likes[i] = name + " " + likes[i];
            }
            Console.WriteLine("\nHere are some facts abou you:\n");
            for (int i = 0; i < likes.Length; i++)
            {
                Console.WriteLine(likes[i]);
            }

            //creates an array and iterates through it
            Console.WriteLine("\nIt seems that you like numbers...I will now count to 10:\n");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //for (int j = 0; j>j-1;  j++)
            for (int j = 0; j < numbers.Length; j++)
            {
                Console.WriteLine(numbers[j]);
            }

            //creates an array and iterates through it
            Console.WriteLine("\nI will now count down from 5:\n");
            for (int j = 4; 0 <= j; j--)
            {
                Console.WriteLine(numbers[j]);
            }

            //creates a list, asks for user input, iterates through list and checks if user input matches with a list item.
            //if the user input isn't on the list, gives an error message to user. If it is, gives a sucess message with index of list item.
            List<string> beerStyles = new List<string>() { "IPA", "PILSNER", "GOSE", "STOUT", "SOUR", "DOUBLE IPA", "HEFEWEIZEN" };
            Console.WriteLine("\nBased on the above facts, you like beer. Please enter a beer style to see if it is available for purchace");
            string selection = Console.ReadLine().ToUpper();
            if (beerStyles.Contains(selection))
            {
                foreach (string style in beerStyles)
                {
                    if (style == selection)
                    {
                        Console.WriteLine("\nThe item number of our " + selection + " is: " + beerStyles.IndexOf(selection));
                    }
                }
            }
            else
            {
                Console.WriteLine("\nSorry, we do not carry that style of beer.");
            }

            //creates a list with duplicates, asks for user input, iterates through list and checks if user input matches with a list item(s).
            //if the user input isn't on the list, gives an error message to user. If it is, gives a sucess message with index of list item(s).
            //counts the number of times a list item matches the user input to stop program from giving duplicate list item indicies multiple times.
            List<string> breweries = new List<string>() { "GREAT NOTION", "ROGUE", "LITTLE BEAST", "ROGUE", "BREAKSIDE", "GREAT NOTION", "WEST COAST GROCERY" };
            Console.WriteLine("\nPlease enter a local brewery to see if we carry their beer");
            string brewery = Console.ReadLine().ToUpper();
            int count = 0;
            if (breweries.Contains(brewery))
            {
                Console.WriteLine("\nThe location number of " + brewery + " is (there may be more than one location): ");
                foreach (string brewer in breweries)
                {
                    if (brewer == brewery && count < 1)
                    {
                        int[] brewLocation = { breweries.IndexOf(brewery), breweries.IndexOf(brewery, breweries.IndexOf(brewery) + 1) };
                        for (int m = 0; m < brewLocation.Length; m++)
                        {
                            if (brewLocation[m] >= 0)
                            {
                                Console.WriteLine(brewLocation[m]);
                            }
                        }
                        count++;
                    }
                }
            }

            else
            {
                Console.WriteLine("Sorry, we do not carry beer from that brewery.");
            }

            //creates a list with duplicates and iterates through the list, prints list with duplicates marked.
            Console.WriteLine("\nYou also appear to like dogs, here is a list of past best in show winners. *Denotes a repeat winner.\n");
            List<string> dogs = new List<string>() { "Airedale", "Irish Wolfhound", "American Staffordshire Terrier", "Airedale", "French Bulldog", "Boston Terrier" };
            List<string> myList = new List<string>();

            // iterate through dogs list and add items in list to a new list.
            // if the items are already on the new list, add an * to them.
            foreach (string dog in dogs)
            {
                if (!myList.Contains(dog))
                {
                    myList.Add(dog);
                }    
                else
                {
                    myList.Add(dog + "*");
                }
            }

            // print the new list with duplicates marked
            foreach (string dog in myList)
            {
                Console.WriteLine(dog);
            }
          
            Console.ReadLine();
        }
    }
}
