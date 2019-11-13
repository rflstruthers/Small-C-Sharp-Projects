using System;

namespace Branching
{
    class Program
    {
        static void Main()
        {
            //int currentTemp = 70;
            //int roomTemp = 70;
            //if (currentTemp == roomTemp)
            //{
            //    Console.WriteLine("It is exactly room temperature");
            //}
            //else if (currentTemp > roomTemp)
            //{
            //    Console.WriteLine("It is warmer than room temperature");
            //}
            //else if (roomTemp > currentTemp)
            //{
            //    Console.WriteLine("Room temp is warmer than current temp");
            //}
            //else
            //{
            //    Console.WriteLine("It is not exactly room temperature");
            //}

            //string comparisonResult = currentTemp == roomTemp ? "It is room temp." : "It is not room temp.";
            //Console.WriteLine(comparisonResult);

            //int roomTemp = 70;
            //Console.WriteLine("Hi, what is your name?");
            //string name = Console.ReadLine();
            //Console.WriteLine("Hi " + name + ", what is the temperature where you are?");
            //int currentTemp = Convert.ToInt32(Console.ReadLine());
            //if (currentTemp == roomTemp)
            //{
            //    Console.WriteLine("It is exactly room temp.");
            //}
            //else if (currentTemp > roomTemp)
            //{
            //    Console.WriteLine("It is warmer than room temp.");
            //}
            //else if (roomTemp > currentTemp)
            //{
            //    Console.WriteLine("It is colder than room temp.");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong");
            //}

            Console.WriteLine("What is your favorite number?");
            int favNum = Convert.ToInt32(Console.ReadLine());
            string result = favNum == 12 ? "You have an awesome favorite number." : "You don't have an awesome favorite number.";
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
