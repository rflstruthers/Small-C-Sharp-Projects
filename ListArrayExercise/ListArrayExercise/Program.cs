using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        string[] stringArray = { "not very happy", "moderately unhappy", "neither happy or unhappy", "moderately happy", "very happy" };

        int[] intArray = {1000000, 20, 30000, 4, 50, 600000, 700, 8000, 90, 100};

        List<string> stringList = new List<string>();
        stringList.Add("inspirational poster");
        stringList.Add("calender");
        stringList.Add("daily planner");
        stringList.Add("book of nature photos");

        Console.WriteLine("On a scale of 0-4 of how happy you are feeling,\nwhere 0 is the least happy and 4 is the most happy,\nplease rate your happiness:");
        int hapiness = Convert.ToInt32(Console.ReadLine());
        bool inRange = false;

        while(!inRange)
        {
            switch (hapiness)
            {
                case int n when n <= 4:
                    Console.WriteLine("You are feeling " + stringArray[hapiness] + " right now.\n\nOkay, now that we've established how happy you are,\nplease enter a number between 0 and 9 to see how much money we will give you!");
                    inRange = true;
                    break;

                default:
                    Console.WriteLine("Please enter a number between 0 and 4.");
                    hapiness = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        }
        
        int money = Convert.ToInt32(Console.ReadLine());
        bool inRange2 = false;

        while(!inRange2)
        {
            switch(money)
            {
                case int m when m <= 9:
                    Console.WriteLine("Congratulations! You will be getting " + intArray[money] + " dollars in the mail! Spend it wisely.\nPick a number between 0 and 3 to receive a bonus gift!");
                    inRange2 = true;
                    break;

                default:
                    Console.WriteLine("Please enter a number between 0 and 9.");
                    money = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        }

        int bonus = Convert.ToInt32(Console.ReadLine());
        bool inRange3 = false;

        while (!inRange3)
        {
            switch (bonus)
            {
                case int l when l <= 3:
                    Console.WriteLine("Awesome! Along with your " + intArray[money] + " dollars, you will also receive a limited edition " + stringList[bonus] + "!");
                    inRange3 = true;
                    break;

                default:
                    Console.WriteLine("Please enter a number between 0 and 3.");
                    bonus = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        }
        Console.ReadLine();
    }
}

