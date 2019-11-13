using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.TwentyOne
{
    public class TwentyOneRules
    {
        //private because it will only be used in this class
        //dictionary of all the cards and their values
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1
        };

        //method to see what a hand is worth, accounting for aces being 1 or 11. takes in list of cards "Hand" and returns an int array.
        private static int[] GetAllPossibleHandValues(List<Card> Hand)
        {
            //counts how many aces
            int aceCount = Hand.Count(x => x.Face == Face.Ace);
            //number of different options for the value of a hand (because an ace can be 1 or 11)
            int[] result = new int[aceCount + 1];
            //takes the sum of the card values in the hand to get the hand value
            int value = Hand.Sum(x => _cardValues[x.Face]);
            //set the hand value to the first spot in the result array
            result[0] = value;
            //if there are no aces in the hand, the result is returned and the method is done
            if (result.Length == 1) return result;
            //way to add 10 to ace value for each ace in the hand and add that to the hand value
            //add each possible hand value to the result array
            for (int i = 1; i < result.Length; i++)
            {
                value += (i * 10);
                result[i] = value;
            }
            return result;
        }

        //method to check if hand has blackjack, takes in a list of cards "Hand" and returns a boolean
        public static bool CheckForBlackJack(List<Card> Hand)
        {
            //makes array of possible hand values, gets the highest hand value and checks if it's 21
            int[] possibleValues = GetAllPossibleHandValues(Hand);
            int value = possibleValues.Max();
            if (value == 21) return true;
            else return false;
        }

        //method to check if hand is bust
        //checks minimum possible value of hand
        public static bool IsBisted(List<Card> Hand)
        {
            int value = GetAllPossibleHandValues(Hand).Min();
            if (value > 21) return true;
            else return false;
        }

        //if dealers hand is 17-21, they have to stay
        public static bool ShouldDealerStay(List<Card> Hand)
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);
            foreach (int value in possibleHandValues)
            {
                if (value > 16 && value < 22)
                {
                    return true;
                }
            }
            return false;
        }
        //method returns nullable bool
        public static bool? CompareHands(List<Card> PlayerHand, List<Card> DealerHand)
        {
            //make array of possible hand values
            int[] playerResults = GetAllPossibleHandValues(PlayerHand);
            int[] dealerResult = GetAllPossibleHandValues(DealerHand);
            //get the largest value under 22
            int playerScore = playerResults.Where(x => x < 22).Max();
            int dealerScore = dealerResult.Where(x => x < 22).Max();
            //did the player win? Null if it's a tie
            if (playerScore > dealerScore) return true;
            else if (playerScore < dealerScore) return false;
            else return null;
        }
    }
}
